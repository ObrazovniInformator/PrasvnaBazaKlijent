using Microsoft.EntityFrameworkCore;

namespace PrasvnaBazaKlijent.Models
{
    public partial class obrazovn_AdminPanelContext : DbContext
    {
        public obrazovn_AdminPanelContext()
        {
        }

        public obrazovn_AdminPanelContext(DbContextOptions<obrazovn_AdminPanelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alineja> Alineja { get; set; }
        //ROLES
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<DonosilacSm> DonosilacSm { get; set; }
        public virtual DbSet<DonosilacSp> DonosilacSp { get; set; }
        public virtual DbSet<GlavneOblasti> GlavneOblasti { get; set; }
        public virtual DbSet<NivoPodnaslova> NivoPodnaslova { get; set; }
        public virtual DbSet<Podnaslov> Podnaslov { get; set; }
        public virtual DbSet<PodpodrubrikaSm> PodpodrubrikaSm { get; set; }
        public virtual DbSet<PodpodrubrikaSp> PodpodrubrikaSp { get; set; }
        public virtual DbSet<Podrubrika> Podrubrika { get; set; }
        public virtual DbSet<PodrubrikaSm> PodrubrikaSm { get; set; }
        public virtual DbSet<PodrubrikaSp> PodrubrikaSp { get; set; }
        public virtual DbSet<Pretplatnik> Pretplatnik { get; set; }
        public virtual DbSet<Propis> Propis { get; set; }
        public virtual DbSet<PropisSluzbenoMisljenje> PropisSluzbenoMisljenje { get; set; }
        public virtual DbSet<PropisSudskaPraksa> PropisSudskaPraksa { get; set; }
        public virtual DbSet<Rubrika> Rubrika { get; set; }
        public virtual DbSet<RubrikaSm> RubrikaSm { get; set; }
        public virtual DbSet<RubrikaSp> RubrikaSp { get; set; }
        public virtual DbSet<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public virtual DbSet<Stav> Stav { get; set; }
        public virtual DbSet<SudskaPraksa> SudskaPraksa { get; set; }
        public virtual DbSet<Tacka> Tacka { get; set; }
        public virtual DbSet<RubrikaVesti> RubrikaVesti { get; set; }
        //VESTI
        public virtual DbSet<Vest> Vest { get; set; }
        //CASOPISI
        public virtual DbSet<CasopisOznaka> CasopisOznaka { get; set; }
        public virtual DbSet<CasopisGodina> CasopisGodina { get; set; }
        public virtual DbSet<CasopisBroj> CasopisBroj { get; set; }
        public virtual DbSet<RubrikaCasopis> RubrikaCasopis { get; set; }
        public virtual DbSet<PodrubrikaCasopis> PodrubrikaCasopis { get; set; }
        public virtual DbSet<PropisCasopis> PropisCasopis { get; set; }
        public virtual DbSet<GlavneOblastiCasopis> GlavneOblastiCasopis { get; set; }
        public virtual DbSet<CasopisNaslov> CasopisNaslov { get; set; }
        public virtual DbSet<PdfFajlCasopis> PdfFajlCasopis { get; set; }
        //INAkta
        public virtual DbSet<InAkta> InAkta { get; set; }
        public virtual DbSet<InAktaPodvrsta> InAktaPodvrsta { get; set; }
        public virtual DbSet<RubrikaInAkta> RubrikaInAkta { get; set; }
        public virtual DbSet<PodrubrikaInAkta> PodrubrikaInAkta { get; set; }
        public virtual DbSet<PodpodrubrikaInAkta> PodpodrubrikaInAkta { get; set; }
        public virtual DbSet<PropisInAkta> PropisInAkta { get; set; }
        //KLIJENT
        public virtual DbSet<Klijent> Klijent { get; set; }
        //PROSVETNI PROPISI
        public virtual DbSet<RubrikaPP> RubrikaPP { get; set; }
        public virtual DbSet<PodrubrikaPP> PodrubrikaPP { get; set; }
        public virtual DbSet<ProsvetniPropis> ProsvetnIPropis { get; set; }
        public virtual DbSet<PodnaslovPP> PodnaslovPP { get; set; }
        public virtual DbSet<ClanPP> ClanPP { get; set; }
        public virtual DbSet<StavPP> StavPP { get; set; }
        public virtual DbSet<TackaPP> TackaPP { get; set; }
        public virtual DbSet<AlinejaPP> AlinejaPP { get; set; }
        public virtual DbSet<ProsvetniPropisInAkta> ProsvetniPropisInAkta { get; set; }
        public virtual DbSet<ProsvetniPropisSluzbenoMisljenje> ProsvetniPropisSluzbenoMisljenje { get; set; }
        //Primeri Knjzenja
        public virtual DbSet<RubrikaPK> RubrikaPK { get; set; }
        public virtual DbSet<PrimeriKnjizenja> PrimeriKnjizenja { get; set; }
        //Vest-Propis veza
        public virtual DbSet<PropisVest> PropisVest { get; set; }
        public virtual DbSet<VestiKategorija> VestiKategorija { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //  #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-J6TSTOI\\SQLEXPRESS;Database=adminPanel;Integrated Security=True;");  
                optionsBuilder.UseSqlServer("Server=tcp:obrazovni-adminpanel.database.windows.net,1433;Initial Catalog=adminPanel;Persist Security Info=False;User ID=Andjelija;Password=Andja#Luka;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alineja>(entity =>
            {
                entity.Property(e => e.NazivAlineje).HasMaxLength(255);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Clan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.HasOne(d => d.IdPodnaslovNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdPodnaslov)
                    .HasConstraintName("FK_Clan_Podnaslovi");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_Clan_Propis1");
            });

            modelBuilder.Entity<DonosilacSm>(entity =>
            {
                entity.ToTable("DonosilacSM");
            });

            modelBuilder.Entity<DonosilacSp>(entity =>
            {
                entity.ToTable("DonosilacSP");
            });

            modelBuilder.Entity<GlavneOblasti>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasMaxLength(255);
            });

            modelBuilder.Entity<NivoPodnaslova>(entity =>
            {
                entity.Property(e => e.Naziv).HasMaxLength(250);
            });

            modelBuilder.Entity<Podnaslov>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNivoPodnaslovaNavigation)
                    .WithMany(p => p.Podnaslov)
                    .HasForeignKey(d => d.IdNivoPodnaslova)
                    .HasConstraintName("FK_Podnaslov_NivoPodnaslova");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.Podnaslov)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_Podnaslov_Propis");
            });

            modelBuilder.Entity<PodpodrubrikaSm>(entity =>
            {
                entity.ToTable("PodpodrubrikaSM");

                entity.HasOne(d => d.IdPodrubrikaNavigation)
                    .WithMany(p => p.PodpodrubrikaSm)
                    .HasForeignKey(d => d.IdPodrubrika)
                    .HasConstraintName("FK_PodpodrubrikaSM_PodrubrikaSM");
            });

            modelBuilder.Entity<PodpodrubrikaSp>(entity =>
            {
                entity.ToTable("PodpodrubrikaSP");

                entity.HasOne(d => d.IdPodrubrikaNavigation)
                    .WithMany(p => p.PodpodrubrikaSp)
                    .HasForeignKey(d => d.IdPodrubrika)
                    .HasConstraintName("FK_PodpodrubrikaSP_PodrubrikaSP");
            });

            modelBuilder.Entity<Podrubrika>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.Podrubrika)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_Podrubrika_Rubrika");
            });

            modelBuilder.Entity<PodrubrikaSm>(entity =>
            {
                entity.ToTable("PodrubrikaSM");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaSm)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaSM_RubrikaSM");
            });

            modelBuilder.Entity<PodrubrikaSp>(entity =>
            {
                entity.ToTable("PodrubrikaSP");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaSp)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaSP_RubrikaSP");
            });

            modelBuilder.Entity<Pretplatnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrojTelefona).HasMaxLength(50);

                entity.Property(e => e.DatumKrajaPretplate).HasMaxLength(50);

                entity.Property(e => e.DatumPocetkaPretplate).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);

                entity.Property(e => e.MaticniBroj).HasMaxLength(50);

                entity.Property(e => e.Pib)
                    .HasColumnName("PIB")
                    .HasMaxLength(50);

                entity.Property(e => e.Pretplata).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(50);
            });

            modelBuilder.Entity<Propis>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatumObjavljivanjaOsnovnogTeksta).HasColumnType("datetime");

                entity.Property(e => e.DatumObjavljivanjaVerzije).HasColumnType("datetime");

                entity.Property(e => e.DatumPocetkaPrimene).HasColumnType("datetime");

                entity.Property(e => e.DatumPrestankaVazenjaPropisa).HasColumnType("datetime");

                entity.Property(e => e.DatumPrestankaVerzije).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguMeđunarodnogUgovora).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguOsnovnogTekstaPropisa).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguVerzijePropisa).HasColumnType("datetime");

                entity.Property(e => e.GlasiloIdatumObjavljivanja).HasColumnName("GlasiloIDatumObjavljivanja");

                entity.Property(e => e.Naslov).HasMaxLength(255);

                entity.Property(e => e.Preambula).IsUnicode(false);

                entity.HasOne(d => d.IdPodrubrikeNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdPodrubrike)
                    .HasConstraintName("FK_Propis_Podrubrika1");

                entity.HasOne(d => d.IdRubrikeNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdRubrike)
                    .HasConstraintName("FK_Propis_Rubrika");
            });

            modelBuilder.Entity<PropisSluzbenoMisljenje>(entity =>
            {
                entity.Property(e => e.DatumUnosa).HasColumnType("datetime");
            });

            modelBuilder.Entity<PropisSudskaPraksa>(entity =>
            {
                entity.Property(e => e.DatumUnosa).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rubrika>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdOblastNavigation)
                    .WithMany(p => p.Rubrika)
                    .HasForeignKey(d => d.IdOblast)
                    .HasConstraintName("FK_Rubrika_GlavneOblasti");
            });

            modelBuilder.Entity<RubrikaSm>(entity =>
            {
                entity.ToTable("RubrikaSM");
            });

            modelBuilder.Entity<RubrikaSp>(entity =>
            {
                entity.ToTable("RubrikaSP");
            });

            modelBuilder.Entity<SluzbenoMisljenje>(entity =>
            {

                entity.Property(e => e.IdDonosilacSm).HasColumnName("IdDonosilacSM");

                entity.Property(e => e.IdPodpodrubrikaSm).HasColumnName("IdPodpodrubrikaSM");

                entity.Property(e => e.IdPodrubrikaSm).HasColumnName("IdPodrubrikaSM");

                entity.Property(e => e.IdRubrikaSm).HasColumnName("IdRubrikaSM");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_SluzbenoMisljenje_Clan");

                entity.HasOne(d => d.IdDonosilacSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdDonosilacSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_DonosilacSM");

                entity.HasOne(d => d.IdPodpodrubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPodpodrubrikaSm)
                    .HasConstraintName("FK_SluzbenoMisljenje_PodpodrubrikaSM");

                entity.HasOne(d => d.IdPodrubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPodrubrikaSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_PodrubrikaSM");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_SluzbenoMisljenje_Propis");

                entity.HasOne(d => d.IdRubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdRubrikaSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_RubrikaSM");

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_SluzbenoMisljenje_Stav");

                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_SluzbenoMisljenje_Tacka");
            });

            modelBuilder.Entity<Stav>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.Stav)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_Stav_Clan");
            });

            modelBuilder.Entity<SudskaPraksa>(entity =>
            {
                //entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.IdDonosilacSp).HasColumnName("IdDonosilacSP");

                entity.Property(e => e.IdPodpodrubrikaSp).HasColumnName("IdPodpodrubrikaSP");

                entity.Property(e => e.IdPodrubrikaSp).HasColumnName("IdPodrubrikaSP");

                entity.Property(e => e.IdRubrikaSp).HasColumnName("IdRubrikaSP");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_SudskaPraksa_Clan");

                entity.HasOne(d => d.IdDonosilacSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdDonosilacSp)
                    .HasConstraintName("FK_SudskaPraksa_DonosilacSP");

                entity.HasOne(d => d.IdPodpodrubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPodpodrubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_PodpodrubrikaSP");

                entity.HasOne(d => d.IdPodrubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPodrubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_PodrubrikaSP");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_SudskaPraksa_Propis");

                entity.HasOne(d => d.IdRubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdRubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_RubrikaSP");

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_SudskaPraksa_Stav");

                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_SudskaPraksa_Tacka");
            });

            modelBuilder.Entity<Tacka>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.Tacka)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_Tacka_Stav");
            });
            modelBuilder.Entity<Vest>(entity =>
            {

                entity.HasOne(d => d.IdRubrikeVestiNavigation)
                    .WithMany(p => p.Vest)
                    .HasForeignKey(d => d.IdRubrikaVesti)
                    .HasConstraintName("FK_Vest_RubrikaVesti");
                entity.HasOne(d => d.IdKategorijaNavigation)
                  .WithMany(p => p.Vest)
                  .HasForeignKey(d => d.IdKategorija)
                  .HasConstraintName("FK_Vest_Kategorija");
            });
            modelBuilder.Entity<CasopisNaslov>(entity =>
            {
                entity.HasOne(d => d.IdRubrikaCasopisNavigation)
                    .WithMany(p => p.CasopisNaslov)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_CasopisNaslov_RubrikaCasopis");
                entity.HasOne(d => d.IdPodrubrikaCasopisNavigation)
                   .WithMany(p => p.CasopisNaslov)
                   .HasForeignKey(d => d.IdPodrubrika)
                   .HasConstraintName("FK_CasopisNaslov_PodrubrikaCasopis");

                entity.HasOne(d => d.IdCasopisBrojNavigation)
                   .WithMany(p => p.CasopisNaslov)
                   .HasForeignKey(d => d.IdBroj)
                   .HasConstraintName("FK_CasopisNaslov_CasopisBroj");

                entity.HasOne(d => d.IdCasopisGodinaNavigation)
                   .WithMany(p => p.CasopisNaslov)
                   .HasForeignKey(d => d.IdGodina)
                   .HasConstraintName("FK_CasopisNaslov_CasopisGodina");

                entity.HasOne(d => d.IdCasopisOznakaNavigation)
                   .WithMany(p => p.CasopisNaslov)
                   .HasForeignKey(d => d.IdOznaka)
                   .HasConstraintName("FK_CasopisNaslov_CasopisOznaka");
            });

            modelBuilder.Entity<PdfFajlCasopis>(entity =>
            {
                entity.HasOne(d => d.IdCasopisNavigation)
                .WithMany(p => p.PdfFajlCasopis)
                .HasForeignKey(d => d.IdCasopis)
                .HasConstraintName("FK_PdfFajl_Casopis");

            });

            modelBuilder.Entity<CasopisBroj>(entity =>
            {
                entity.HasOne(d => d.IdCasopisGodinaNavigation)
                    .WithMany(p => p.CasopisBroj)
                    .HasForeignKey(d => d.IdGodina)
                    .HasConstraintName("FK_CasopisBroj_CasopisGodina");
            });

            modelBuilder.Entity<CasopisGodina>(entity =>
            {
                entity.HasOne(d => d.IdGlavneOblastiCasopisNavigation)
                    .WithMany(p => p.CasopisGodina)
                    .HasForeignKey(d => d.IdGlavneOblastiCasopis)
                    .HasConstraintName("FK_CasopisGodina_GlavneOblastiCasopis");
            });

            modelBuilder.Entity<RubrikaCasopis>(entity =>
            {
                entity.HasOne(d => d.IdCasopisBrojNavigation)
                    .WithMany(p => p.RubrikaCasopis)
                    .HasForeignKey(d => d.IdBroj)
                    .HasConstraintName("FK_RubrikaCasopis_CasopisBroj");
            });
            modelBuilder.Entity<PodrubrikaCasopis>(entity =>
            {
                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaCasopis)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_RubrikaCasopis_PodrubrikaCasopis");
            });
            modelBuilder.Entity<PropisCasopis>(entity =>
            {
                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.PropisCasopis)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_PropisCasopis_Propis");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.PropisCasopis)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_PropisCasopis_Clan");
                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.PropisCasopis)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_PropisCasopis_Stav");
                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.PropisCasopis)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_PropisCasopis_Tacka");
                entity.HasOne(d => d.IdCasopisNaslovNavigation)
                    .WithMany(p => p.PropisCasopis)
                    .HasForeignKey(d => d.IdCasopis)
                    .HasConstraintName("FK_PropisCasopis_CasopisNaslov");

            });
            modelBuilder.Entity<PodpodrubrikaInAkta>(entity =>
            {
                entity.HasOne(d => d.IdPodrubrikaInAktaNavigation)
                    .WithMany(p => p.PodpodrubrikaInAkta)
                    .HasForeignKey(d => d.IdPodrubrika)
                    .HasConstraintName("FK_PodpodrubrikaInAkta_PodrubrikaInAkta");
            });

            modelBuilder.Entity<PodrubrikaInAkta>(entity =>
            {
                entity.HasOne(d => d.IdRubrikaInAktaNavigation)
                    .WithMany(p => p.PodrubrikaInAkta)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaInAkta_RubrikaInAkta");
            });

            modelBuilder.Entity<RubrikaInAkta>(entity =>
            {
                entity.HasOne(d => d.IdInAktaPodvrstaNavigation)
                    .WithMany(p => p.RubrikaInAkta)
                    .HasForeignKey(d => d.IdPodvrsta)
                    .HasConstraintName("FK_RubrikaInAkta_InAktaPodvrsta");
            });

            modelBuilder.Entity<PropisInAkta>(entity =>
            {
                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.PropisInAkta)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_PropisInAkta_Propis");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.PropisInAkta)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_PropisInAkta_Clan");
                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.PropisInAkta)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_PropisInAkta_Stav");
                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.PropisInAkta)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_PropisCasopis_Tacka");
                entity.HasOne(d => d.IdInAktaNavigation)
                    .WithMany(p => p.PropisInAkta)
                    .HasForeignKey(d => d.IdInAkta)
                    .HasConstraintName("FK_PropisInAkta_InAkta");
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.Property(e => e.Ime).HasMaxLength(50);
                entity.Property(e => e.Prezime).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Lozinka).HasMaxLength(50);
                entity.Property(e => e.BrojTelefona).HasMaxLength(50);
            });
            modelBuilder.Entity<PodrubrikaPP>(entity =>
            {
                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaPP)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaPP_RubrikaPP");
            });
            modelBuilder.Entity<ProsvetniPropis>(entity =>
            {
                entity.HasOne(d => d.IdPodrubrikaNavigation)
                       .WithMany(p => p.ProsvetniPropis)
                       .HasForeignKey(d => d.IdPodrubrike)
                       .HasConstraintName("FK_ProsvetniPropis_PodrubrikaPP");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.ProsvetniPropis)
                    .HasForeignKey(d => d.IdRubrike)
                    .HasConstraintName("FK_Propis_Rubrika");
            });
            modelBuilder.Entity<PodnaslovPP>(entity =>
            {
                entity.HasOne(d => d.IdPropisNavigation)
                   .WithMany(p => p.PodnaslovPP)
                   .HasForeignKey(d => d.IdPropis)
                   .HasConstraintName("FK_PodnaslovPP_ProsvetniPropis");

                entity.HasOne(d => d.IdNivoPodnaslovaNavigation)
                   .WithMany(p => p.PodnaslovPP)
                   .HasForeignKey(d => d.IdNivoPodnaslova)
                   .HasConstraintName("FK_PodnaslovPP_NivoPodnaslova");

            });
            modelBuilder.Entity<ClanPP>(entity =>
            {
                entity.HasOne(d => d.IdPodnaslovNavigation)
                       .WithMany(p => p.ClanPP)
                       .HasForeignKey(d => d.IdPodnaslov)
                       .HasConstraintName("FK_ClanPP_Podnaslov");
                entity.HasOne(d => d.IdPropisNavigation)
                       .WithMany(p => p.ClanPP)
                       .HasForeignKey(d => d.IdPropis)
                       .HasConstraintName("FK_ClanPP_Propis");
            });
            modelBuilder.Entity<StavPP>(entity =>
            {
                entity.HasOne(d => d.IdClanNavigation)
                       .WithMany(p => p.StavPP)
                       .HasForeignKey(d => d.IdClan)
                       .HasConstraintName("FK_StavPP_ClanPP");
            });
            modelBuilder.Entity<TackaPP>(entity =>
            {
                entity.HasOne(d => d.IdStavNavigation)
                       .WithMany(p => p.TackaPP)
                       .HasForeignKey(d => d.IdStav)
                       .HasConstraintName("FK_TackaPP_StavPP");
            });
            modelBuilder.Entity<AlinejaPP>(entity =>
            {
                entity.HasOne(d => d.IdStavNavigation)
                       .WithMany(p => p.AlinejaPP)
                       .HasForeignKey(d => d.IdStav)
                       .HasConstraintName("FK_AlinejaPP_StavPP");
            });
            modelBuilder.Entity<ProsvetniPropisInAkta>(entity =>
            {
                entity.HasOne(d => d.IdProsvetniPropisNavigation)
                    .WithMany(p => p.ProsvetniPropisInAkta)
                    .HasForeignKey(d => d.IdProsvetniPropis)
                    .HasConstraintName("FK_ProsvetniPropisInAkta_Propis");
                entity.HasOne(d => d.IdClanPPNavigation)
                    .WithMany(p => p.ProsvetniPropisInAkta)
                    .HasForeignKey(d => d.IdClanPP)
                    .HasConstraintName("FK_ProsvetniPropisInAkta_ClanPP");
                entity.HasOne(d => d.IdStavPPNavigation)
                    .WithMany(p => p.ProsvetniPropisInAkta)
                    .HasForeignKey(d => d.IdStavPP)
                    .HasConstraintName("FK_ProsvetniPropisInAkta_StavPP");
                entity.HasOne(d => d.IdTackaPPNavigation)
                    .WithMany(p => p.ProsvetniPropisInAkta)
                    .HasForeignKey(d => d.IdTackaPP)
                    .HasConstraintName("FK_ProsvetniPropisInAkta_TackaPP");
                entity.HasOne(d => d.IdInAktaNavigation)
                    .WithMany(p => p.ProsvetniPropisInAkta)
                    .HasForeignKey(d => d.IdInAkta)
                    .HasConstraintName("FK_ProsvetniPropisInAkta_InAktaPP");
            });
            modelBuilder.Entity<ProsvetniPropisSluzbenoMisljenje>(entity =>
            {
                entity.HasOne(d => d.IdProsvetniPropisNavigation)
                    .WithMany(p => p.ProsvetniPropisSluzbenoMisljenje)
                    .HasForeignKey(d => d.IdProsvetniPropis)
                    .HasConstraintName("FK_ProsvetniPropisSluzbenoMisljenje_Propis");
                entity.HasOne(d => d.IdClanPPNavigation)
                    .WithMany(p => p.ProsvetniPropisSluzbenoMisljenje)
                    .HasForeignKey(d => d.IdClanPP)
                    .HasConstraintName("FK_ProsvetniPropisSluzbenoMisljenje_ClanPP");
                entity.HasOne(d => d.IdStavPPNavigation)
                    .WithMany(p => p.ProsvetniPropisSluzbenoMisljenje)
                    .HasForeignKey(d => d.IdStavPP)
                    .HasConstraintName("FK_ProsvetniPropisSluzbenoMisljenje_StavPP");
                entity.HasOne(d => d.IdTackaPPNavigation)
                    .WithMany(p => p.ProsvetniPropisSluzbenoMisljenje)
                    .HasForeignKey(d => d.IdTackaPP)
                    .HasConstraintName("FK_ProsvetniPropisSluzbenoMisljenje_TackaPP");
                entity.HasOne(d => d.IdSluzbenoMisljenjeNavigation)
                    .WithMany(p => p.ProsvetniPropisSluzbenoMisljenje)
                    .HasForeignKey(d => d.IdSluzbenoMisljenje)
                    .HasConstraintName("FK_ProsvetniPropisSluzbenoMisljenje_SluzbenoMisljenjePP");
            });
            modelBuilder.Entity<PrimeriKnjizenja>(entity =>
            {

                entity.HasOne(d => d.IdRubrkaPKNavigation)
                    .WithMany(p => p.PrimeriKnjizenja)
                    .HasForeignKey(d => d.IdRubrikaPK)
                    .HasConstraintName("FK_PrimeriKnjizenja_Rubrka");


            });
            modelBuilder.Entity<PropisVest>(entity =>
            {
                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.PropisVest)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_PropisVest_Propis");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.PropisVest)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_PropisVest_Clan");
                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.PropisVest)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_PropisVest_Stav");
                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.PropisVest)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_PropisVest_Tacka");
                entity.HasOne(d => d.IdVestNavigation)
                    .WithMany(p => p.PropisVest)
                    .HasForeignKey(d => d.IdVest)
                    .HasConstraintName("FK_PropisVest_CasopisNaslov");
            });
        }
    }
}
