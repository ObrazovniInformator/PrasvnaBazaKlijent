using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrasvnaBazaKlijent.Models;
using Rotativa.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace PrasvnaBazaKlijent.Controllers
{
    [Authorize]
    public class TekstPropisaController : Controller
    {
        //obrazovn_AdminPanelContext _context = new obrazovn_AdminPanelContext();

        public IActionResult Index(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis propis = (from pr in _context.Propis
                                 where pr.Id == id
                                 select pr).AsNoTracking().Single();
                List<Podnaslov> podnaslov = (from p in _context.Podnaslov
                                             where p.IdPropis == propis.Id
                                             select p).AsNoTracking().ToList();
                var clan = (from c in _context.Clan
                            where c.IdPropis == propis.Id
                            select c).AsNoTracking().ToList();

                List<int> clanId = (from c in _context.Clan
                                    where c.IdPropis == propis.Id
                                    select c.Id).ToList();

                List<Stav> stav = (from s in _context.Stav
                                   where clanId.Contains((int)s.IdClan)
                                   select s).AsNoTracking().ToList();




                var stavId = (from s in _context.Stav
                              where clanId.Contains((int)s.IdClan)
                              select s.Id).ToList();

                List<Tacka> tacka = (from s in _context.Tacka
                                     where stavId.Contains((int)s.IdStav)
                                     select s).AsNoTracking().ToList();


                List<Alineja> alineja = (from s in _context.Alineja
                                         where stavId.Contains((int)s.IdStav)
                                         select s).AsNoTracking().ToList();


                //VEZA SA SLUZBENIM MISLJENJEM
                List<PropisSluzbenoMisljenje> vezeSluzbenoMisljenje = (from v in _context.PropisSluzbenoMisljenje
                                                                       where v.IdPropis == id
                                                                       select v).Distinct().AsNoTracking().ToList();
                List<int> idVezeSm = (from veza in _context.PropisSluzbenoMisljenje
                                      where veza.IdPropis == id
                                      select veza.IdSluzbenoMisljenje).Distinct().ToList();
                List<int> idStavovaDis = (from st in _context.PropisSluzbenoMisljenje
                                          where st.IdPropis == id
                                          select st.IdStav).Distinct().ToList();
                List<SluzbenoMisljenje> sluzbenaMisljenja = (from sm in _context.SluzbenoMisljenje
                                                             where idVezeSm.Contains(sm.Id)
                                                             select sm).AsNoTracking().ToList();

                //VEZA SA INAKTIMA
                List<PropisInAkta> vezeInAkta = (from ina in _context.PropisInAkta
                                                 where ina.IdPropis == id
                                                 select ina).AsNoTracking().ToList();
                List<int?> vezeIdInAkta = (from veza in _context.PropisInAkta
                                           where veza.IdPropis == id
                                           select veza.IdInAkta).Distinct().ToList();
                List<InAkta> inAkta = (from i in _context.InAkta
                                       where vezeIdInAkta.Contains(i.Id)
                                       select i).AsNoTracking().ToList();
                List<int?> idStavovaInAktaDis = (from ina in _context.PropisInAkta
                                                 where ina.IdPropis == id
                                                 select ina.IdStav).Distinct().ToList();
                //VEZE SA SUDSKOM PRARKSOM
                List<PropisSudskaPraksa> vezeSudskaPraksa = (from sp in _context.PropisSudskaPraksa
                                                             where sp.IdPropis == id
                                                             select sp).AsNoTracking().ToList();
                List<int> vezeIdSp = (from veza in _context.PropisSudskaPraksa
                                      where veza.IdPropis == id
                                      select veza.IdSudskaPraksa).ToList();

                List<SudskaPraksa> sudskaPraksa = (from sp in _context.SudskaPraksa
                                                   where vezeIdSp.Contains(sp.Id)
                                                   select sp).AsNoTracking().ToList();

                List<int> idStavovaSP = (from spv in _context.PropisSudskaPraksa
                                         where spv.IdPropis == id
                                         select spv.IdStav).Distinct().ToList();
                ViewBag.Propis = propis;
                ViewBag.Podnaslovi = podnaslov;
                ViewBag.Clanovi = clan;
                ViewBag.Stavovi = stav;
                ViewBag.Tacke = tacka;
                ViewBag.Alineje = alineja;
                //SLUZBENO MISLJENJE
                ViewBag.VezeSluzbenoMisljenje = vezeSluzbenoMisljenje;
                ViewBag.IdStavovaDis = idStavovaDis;
                ViewBag.SluzbenaMisljenja = sluzbenaMisljenja;
                //INAKTA
                ViewBag.VezeInAkta = vezeInAkta;
                ViewBag.InAkta = inAkta;
                ViewBag.InAktaStavoviDis = idStavovaInAktaDis;
                //SUDSKA PRAKSA
                ViewBag.VezeSudskaPraksa = vezeSudskaPraksa;
                ViewBag.SudskaPraksa = sudskaPraksa;
                ViewBag.SPStavoviDis = idStavovaSP;

                return View();
            }
        }

        [HttpGet]
        public IActionResult VezaPropisSm(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis propis = _context.Propis.Find(id);
                SluzbenoMisljenje sm = _context.SluzbenoMisljenje.Find(idSm);
                List<Podnaslov> podnaslov = (from p in _context.Podnaslov
                                             where p.IdPropis == propis.Id
                                             select p).AsNoTracking().ToList();
                List<Clan> clan = (from c in _context.Clan
                                   where c.IdPropis == propis.Id
                                   select c).AsNoTracking().ToList();
                List<int> clanId = (from c in _context.Clan
                                    where c.IdPropis == propis.Id
                                    select c.Id).ToList();
                List<Stav> stav = (from st in _context.Stav
                                   where clanId.Contains((int)st.IdClan)
                                   select st).AsNoTracking().ToList();

                var stavId = (from s in _context.Stav
                              where clanId.Contains((int)s.IdClan)
                              select s.Id).ToList();

                List<Tacka> tacka = (from tac in _context.Tacka
                                     where stavId.Contains((int)tac.IdStav)
                                     select tac).AsNoTracking().ToList();


                List<Alineja> alineja = (from a in _context.Alineja
                                         where stavId.Contains((int)a.IdStav)
                                         select a).AsNoTracking().ToList();

                ViewBag.Propis = propis;
                ViewBag.SluzbenoMisljenje = sm;
                ViewBag.Podnaslovi = podnaslov;
                ViewBag.Clanovi = clan;
                ViewBag.Stavovi = stav;
                ViewBag.Tacke = tacka;
                ViewBag.Alineje = alineja;
                return View();
            }
        }

        [HttpGet]
        public IActionResult VezaPropisInAkta(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis p = _context.Propis.Find(id);
                List<Podnaslov> podnaslovi = (from pd in _context.Podnaslov
                                              where pd.IdPropis == id
                                              select pd).AsNoTracking().ToList();
                List<Clan> clanovi = (from cl in _context.Clan
                                      where cl.IdPropis == id
                                      select cl).AsNoTracking().ToList();
                List<int> idClanova = (from cl in _context.Clan
                                       where cl.IdPropis == id
                                       select cl.Id).ToList();
                List<Stav> stavovi = (from st in _context.Stav
                                      where idClanova.Contains((int)st.IdClan)
                                      select st).AsNoTracking().ToList();
                List<int> idStavova = (from st in _context.Stav
                                       where idClanova.Contains((int)st.IdClan)
                                       select st.Id).ToList();
                List<Tacka> tacke = (from tac in _context.Tacka
                                     where idStavova.Contains((int)tac.IdStav)
                                     select tac).AsNoTracking().ToList();
                List<Alineja> alineje = (from al in _context.Alineja
                                         where idStavova.Contains((int)al.IdStav)
                                         select al).AsNoTracking().ToList();
                InAkta inAkta = (from iina in _context.InAkta
                                 where iina.Id == idSm
                                 select iina).AsNoTracking().Single();

                ViewBag.Propis = p;
                ViewBag.InAkta = inAkta;
                ViewBag.Podnaslovi = podnaslovi;
                ViewBag.Clanovi = clanovi;
                ViewBag.Stavovi = stavovi;
                ViewBag.Tacke = tacke;
                ViewBag.Alineje = alineje;

                return View();
            }

        }

        [HttpGet]
        public IActionResult VezaPropisSP(int id, int idSm)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis p = _context.Propis.Find(id);
                List<Podnaslov> podnaslovi = (from pd in _context.Podnaslov
                                              where pd.IdPropis == id
                                              select pd).AsNoTracking().ToList();

                List<Clan> clanovi = (from cl in _context.Clan
                                      where cl.IdPropis == id
                                      select cl).AsNoTracking().ToList();

                List<int> idClanova = (from cl in _context.Clan
                                       where cl.IdPropis == id
                                       select cl.Id).ToList();

                List<Stav> stavovi = (from st in _context.Stav
                                      where idClanova.Contains((int)st.IdClan)
                                      select st).AsNoTracking().ToList();

                List<int> idStavova = (from st in _context.Stav
                                       where idClanova.Contains((int)st.IdClan)
                                       select st.Id).ToList();

                List<Tacka> tacke = (from tac in _context.Tacka
                                     where idStavova.Contains((int)tac.IdStav)
                                     select tac).AsNoTracking().ToList();

                List<Alineja> alineje = (from al in _context.Alineja
                                         where idStavova.Contains((int)al.IdStav)
                                         select al).AsNoTracking().ToList();

                SudskaPraksa sudskaPraksa = (from iina in _context.SudskaPraksa
                                             where iina.Id == idSm
                                             select iina).AsNoTracking().Single();

                ViewBag.Propis = p;
                ViewBag.SudskaPraksa = sudskaPraksa;
                ViewBag.Podnaslovi = podnaslovi;
                ViewBag.Clanovi = clanovi;
                ViewBag.Stavovi = stavovi;
                ViewBag.Tacke = tacke;
                ViewBag.Alineje = alineje;

                return View();
            }
        }

        public IActionResult StampajPropis(int id)
        {
            using (new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            using (var _context = new obrazovn_AdminPanelContext())
            {
                Propis propis = _context.Propis.Find(id);
                return new ViewAsPdf("StampajPropis", propis);
            }


        }



    }
}