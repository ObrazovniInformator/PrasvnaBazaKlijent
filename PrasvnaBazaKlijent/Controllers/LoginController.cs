using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrasvnaBazaKlijent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PrasvnaBazaKlijent.Controllers
{
    public class LoginController : Controller
    {
        obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        [HttpGet]
        public IActionResult Index(string ReturnUrl)
        {
            DeleteCookies();
            if (String.IsNullOrEmpty(ReturnUrl))
            {
                ReturnUrl = "/Home/Index";
            }
            ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string ReturnUrl, [Bind] Pretplatnik pretplatnik)
        {
            var pretplatnici = new Pretplatnik();
            List<Pretplatnik> sviPretplatnici = _context.Pretplatnik.ToList();

            Enkripcija enkripcija = new Enkripcija();

            try
            {
                if (sviPretplatnici.Any(p => p.Email == pretplatnik.Email && pretplatnik.Lozinka.Equals(enkripcija.Decrypt(p.Lozinka))))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, ""),
                        new Claim(ClaimTypes.Email, pretplatnik.Email),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(4)
                    });

                    return RedirectPermanent(ReturnUrl);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            ViewBag.Msg = "Нисте правилно унели параметре";
            return View(pretplatnik);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(-1)
            });

            return RedirectToActionPermanent("Index", "Login");
        }

        private void DeleteCookies()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
        }
    }

    public class Enkripcija
    {
        public string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Nesa"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Nesa"));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}