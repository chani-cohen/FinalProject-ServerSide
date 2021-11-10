using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_Demo_Contacts.Models
{
    public partial class TravelsContext : DbContext
    {
        public TravelsContext()
        {
        }

        public TravelsContext(DbContextOptions<TravelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBoringBussesForTravels> TblBoringBussesForTravels { get; set; }
        public virtual DbSet<TblBoringCustomersForBusses> TblBoringCustomersForBusses { get; set; }
        public virtual DbSet<TblBusses> TblBusses { get; set; }
        public virtual DbSet<TblCustomers> TblCustomers { get; set; }
        public virtual DbSet<TblDrivers> TblDrivers { get; set; }
        public virtual DbSet<TblNeighborhoods> TblNeighborhoods { get; set; }
        public virtual DbSet<TblOrders> TblOrders { get; set; }
        public virtual DbSet<TblSites> TblSites { get; set; }
        public virtual DbSet<TblStations> TblStations { get; set; }
        public virtual DbSet<TblStreets> TblStreets { get; set; }
        public virtual DbSet<TblTickets> TblTickets { get; set; }
        public virtual DbSet<TblTravels> TblTravels { get; set; }
        public virtual DbSet<TblTypesOfUsers> TblTypesOfUsers { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13; DataBase=Travels;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBoringBussesForTravels>(entity =>
            {
                entity.HasKey(e => e.BoringBussesId)
                    .HasName("PK__tbl_Bori__6446277291C31336");

                entity.ToTable("tbl_BoringBussesForTravels");

                entity.Property(e => e.BoringBussesId).HasColumnName("boringBusses_Id");

                entity.Property(e => e.CmBus)
                    .IsRequired()
                    .HasColumnName("cmBus")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.CmBusNavigation)
                    .WithMany(p => p.TblBoringBussesForTravels)
                    .HasForeignKey(d => d.CmBus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__cmBus__3C69FB99");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TblBoringBussesForTravels)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__drive__3D5E1FD2");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.TblBoringBussesForTravels)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__trave__3E52440B");
            });

            modelBuilder.Entity<TblBoringCustomersForBusses>(entity =>
            {
                entity.HasKey(e => e.BoringCustomersForBussesId)
                    .HasName("PK__tbl_Bori__63CB5D672D1ADAFE");

                entity.ToTable("tbl_BoringCustomersForBusses");

                entity.Property(e => e.BoringCustomersForBussesId)
                    .HasColumnName("BoringCustomersForBusses_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoringBussesId).HasColumnName("boringBusses_Id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.TicketId).HasColumnName("ticketId");

                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.BoringBusses)
                    .WithMany(p => p.TblBoringCustomersForBusses)
                    .HasForeignKey(d => d.BoringBussesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__borin__3F466844");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.TblBoringCustomersForBusses)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__email__403A8C7D");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TblBoringCustomersForBusses)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__ticke__412EB0B6");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.TblBoringCustomersForBusses)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Borin__trave__4222D4EF");
            });

            modelBuilder.Entity<TblBusses>(entity =>
            {
                entity.HasKey(e => e.CmBus)
                    .HasName("PK__tbl_Buss__60E0AA153D93DDEB");

                entity.ToTable("tbl_Busses");

                entity.Property(e => e.CmBus)
                    .HasColumnName("cmBus")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50);

                entity.Property(e => e.SeveralPlaces).HasColumnName("severalPlaces");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblCustomers>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__tbl_Cust__AB6E6165434935DC");

                entity.ToTable("tbl_Customers");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.HouseNumber).HasColumnName("houseNumber");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhoodId");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StreetId).HasColumnName("streetId");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK__tbl_Custo__neigh__4316F928");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.TblCustomers)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK__tbl_Custo__stree__440B1D61");
            });

            modelBuilder.Entity<TblDrivers>(entity =>
            {
                entity.HasKey(e => e.DriverId)
                    .HasName("PK__tbl_Driv__F1532DF26C315937");

                entity.ToTable("tbl_Drivers");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tz)
                    .HasColumnName("tz")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblNeighborhoods>(entity =>
            {
                entity.HasKey(e => e.NeighborhoodId)
                    .HasName("PK__tbl_Neig__6A46AA77FC485492");

                entity.ToTable("tbl_Neighborhoods");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhoodId");

                entity.Property(e => e.NeighborhoodName)
                    .IsRequired()
                    .HasColumnName("neighborhoodName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tbl_Orde__0809335D5FAB7129");

                entity.ToTable("tbl_Orders");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SendMessageAboutStation).HasColumnName("sendMessageAboutStation");

                entity.Property(e => e.StationId).HasColumnName("stationId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SumToPay).HasColumnName("sumToPay");

                entity.Property(e => e.TicketId).HasColumnName("ticketId");

                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__email__44FF419A");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK__tbl_Order__stati__45F365D3");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__ticke__46E78A0C");

                entity.HasOne(d => d.Travel)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.TravelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Order__trave__47DBAE45");
            });

            modelBuilder.Entity<TblSites>(entity =>
            {
                entity.HasKey(e => e.SiteId)
                    .HasName("PK__tbl_Site__EAF19B39C8F213C1");

                entity.ToTable("tbl_Sites");

                entity.Property(e => e.SiteId).HasColumnName("siteId");

                entity.Property(e => e.NameSite)
                    .IsRequired()
                    .HasColumnName("nameSite")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblStations>(entity =>
            {
                entity.HasKey(e => e.StationId)
                    .HasName("PK__tbl_Stat__F0A7F380489436E7");

                entity.ToTable("tbl_Stations");

                entity.Property(e => e.StationId).HasColumnName("stationId");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhoodId");

                entity.Property(e => e.StationAddress)
                    .IsRequired()
                    .HasColumnName("stationAddress");

                entity.Property(e => e.StreetId).HasColumnName("streetId");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.TblStations)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK__tbl_Stati__neigh__48CFD27E");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.TblStations)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK__tbl_Stati__stree__49C3F6B7");
            });

            modelBuilder.Entity<TblStreets>(entity =>
            {
                entity.HasKey(e => e.StreetId)
                    .HasName("PK__tbl_Stre__423E0258D15375C8");

                entity.ToTable("tbl_Streets");

                entity.Property(e => e.StreetId).HasColumnName("streetId");

                entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhoodId");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasColumnName("streetName");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.TblStreets)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK__tbl_Stree__neigh__4AB81AF0");
            });

            modelBuilder.Entity<TblTickets>(entity =>
            {
                entity.HasKey(e => e.TicketId);

                entity.ToTable("tbl_Tickets");

                entity.Property(e => e.TicketId).HasColumnName("ticketId");

                entity.Property(e => e.FromAge).HasColumnName("fromAge");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SiteId).HasColumnName("siteId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UntilAge).HasColumnName("untilAge");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.TblTickets)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Ticke__siteI__4BAC3F29");
            });

            modelBuilder.Entity<TblTravels>(entity =>
            {
                entity.HasKey(e => e.TravelId)
                    .HasName("PK__tbl_Trav__082EFC1F4F549439");

                entity.ToTable("tbl_Travels");

                entity.Property(e => e.TravelId).HasColumnName("travelId");

                entity.Property(e => e.LeavingTime)
                    .HasColumnName("leavingTime")
                    .HasColumnType("time(4)");

                entity.Property(e => e.MaximunNumberOfPlaces).HasColumnName("maximunNumberOfPlaces");

                entity.Property(e => e.ReturnTime)
                    .HasColumnName("returnTime")
                    .HasColumnType("time(4)");

                entity.Property(e => e.SiteId).HasColumnName("siteId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TravelDate)
                    .HasColumnName("travelDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.TblTravels)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Trave__siteI__4CA06362");
            });

            modelBuilder.Entity<TblTypesOfUsers>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("PK__tbl_Type__9D31027E35C2EF7C");

                entity.ToTable("tbl_TypesOfUsers");

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("userType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_Users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Users__email__4D94879B");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Users__userT__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
