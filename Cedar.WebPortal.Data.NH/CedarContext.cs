namespace Cedar.WebPortal.Data
{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.ModelConfiguration.Conventions;
//    using System.Data.Entity.Validation;
//    using System.Diagnostics;

    using Cedar.WebPortal.Domain;

//    public sealed class CedarContext : DbContext, ICedarContext
//    {
//        #region Constants and Fields
//
//        private static int i;
//
//        #endregion
//
//        #region Constructors and Destructors
//
//        public CedarContext()
//            : base("CedarContext")
//        {
//            Debug.Print(i++.ToString());
//#if DEBUG
//
//            Database.SetInitializer(new CustomDatabaseInitializer<CedarContext>());
//#else
//            Database.SetInitializer(new CreateDatabaseIfNotExists<CedarContext>());
//#endif
//        }
//
//        #endregion
//
//        #region Properties
//
//        public DbSet<Applicant> Applicant { get; set; }
//
//        public DbSet<Attachment> Attachment { get; set; }
//
//        public DbSet<Company> Company { get; set; }
//
//        public DbSet<Distributor> Distributor { get; set; }
//
//        public DbSet<JobPosition> JobPosition { get; set; }
//
//        public DbSet<Message> Message { get; set; }
//
//        public DbSet<News> News { get; set; }
//
//        #endregion
//
//        #region Implemented Interfaces
//
//        #region ICedarContext
//
//        public void Commit()
//        {
//            try
//            {
//                this.SaveChanges();
//            }
//            catch (DbEntityValidationException dbEx)
//            {
//                foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors)
//                {
//                    foreach (DbValidationError validationError in validationErrors.ValidationErrors)
//                    {
//                        Trace.TraceInformation(
//                            "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
//                    }
//                }
//            }
//            catch (Exception ee)
//            {
//                throw;
//            }
//        }
//
//        #endregion
//
//        #endregion
//
//        #region Methods
//
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Build(this.Database.Connection);
//            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//
//            modelBuilder.ComplexType<User>();
//            modelBuilder.Entity<News>().HasKey(o => o.NewsId).HasOptional(o => o.Attachment).WithOptionalPrincipal();
//
//            modelBuilder.Entity<Applicant>().HasKey(o => o.ApplicantId).Ignore(o => o.Gender);
//            modelBuilder.Entity<Applicant>().HasOptional(o => o.Picture);
//            modelBuilder.Entity<Applicant>().HasOptional(o => o.CV);
//
//            modelBuilder.Entity<HabitationInfo>().HasKey(o => o.HabitationInfoId).Ignore(o => o.HabitaionType);
//            modelBuilder.Entity<EducationInfo>().HasKey(o => o.EducationInfoId).Ignore(o => o.Level);
//            modelBuilder.ComplexType<SocialSecurityInfo>();
//            modelBuilder.ComplexType<MilitaryServiceInfo>().Ignore(o => o.Status);
//
//            modelBuilder.Entity<Attachment>().HasKey(o => o.AttachmentId);
//
//            modelBuilder.Entity<Company>().HasKey(o => o.CompanyId).HasMany(o => o.EquipProductInfos);
//            modelBuilder.Entity<Company>().Ignore(x => x.Form);
//
//            modelBuilder.Entity<JobPosition>().HasKey(o => o.JobPositionId).Property(o => o.Xmlfile).HasColumnType("xml");
//
//            modelBuilder.Entity<Distributor>().HasKey(o => o.DistributorId).Ignore(x => x.Form);
//            modelBuilder.Entity<OtherOperatorsSellInfo>().HasKey(o => o.OtherOperatorsSellInfoId).HasMany(
//                x => x.Locations).WithMany();
//            modelBuilder.Entity<OtherOperatorsSellInfo>().Ignore(x => x.ProductType);
//            modelBuilder.Entity<OtherOperatorsSellInfo>().Ignore(x => x.OpratorName);
//        }
//
//        #endregion
//    }
}