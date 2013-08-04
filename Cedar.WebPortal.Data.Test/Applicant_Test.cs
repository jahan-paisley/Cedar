namespace Cedar.WebPortal.Data.Test
{
    using System;
//    using System.Data.Entity.Infrastructure;

    using Cedar.WebPortal.Domain;

    using System.Linq;

//    [TestFixture]
//    public class Applicant_Test
//    {
//        [Test]
//        public static void Applicant_Create_Test()
//        {
//            var context = new CedarContext();
//            var applicant = context.Applicant.Create();
//            CreateNewApplication(applicant);
//            applicant.Publications.Add(new Publication{Title = "salam", });
//            context.Applicant.Add(applicant);
//            context.Commit();
//        }
//
//        public static void CreateNewApplication(Applicant applicant)
//        {
//            applicant.FirstName = "First Name";
//            applicant.LastName = "Last Name";
//            applicant.FatherName = "Father Name";
//            applicant.BirthDate = DateTime.Now.AddYears(-20);
//            applicant.NationalNo = 1234567891;
//            applicant.TelNo = 166951587;
//
//            applicant.Gender = Gender.Male;
//            applicant.IdentityNo = "123";
//            applicant.MobileNo = "09127845241";
//            applicant.EmeregencyTelNo = "123123123";
//            applicant.Address = "Address";
//            applicant.EMail = "email@example.com";
//        }
//
//        [Test]
//        public void One_To_One_Relationship_Test()
//        {
//            Applicant applicant = Create();
//            Applicant find = this.FindById(applicant.ApplicantId);
//            Assert.IsTrue(find.Equals(applicant));
//            Assert.IsTrue(applicant.SocialSecurityInfo.Equals(find.SocialSecurityInfo));
//            Assert.IsTrue(applicant.EducationInfos.Count == 1);
//            (new CedarContext()).Applicant.Remove(applicant);
//        }
//
//        [Test]
//        public void One_To_Many_Update_Relationship_Test()
//        {
//            Applicant applicant = Create();
//            var context1 = new CedarContext();
//            Applicant find = this.FindInContext(context1, applicant.ApplicantId);
//
//            find.EducationInfos.First().Major = "Updated";
//            context1.SaveChanges();
//            context1.Commit();
//            var context2 = new CedarContext();
//            Applicant find2 = this.FindInContext(context2, applicant.ApplicantId);
//            Assert.IsTrue(find2.EducationInfos.First().Major == "Updated");
//            context2.Applicant.Remove(find2);
//        }        
//        
//        [Test]
//        public void One_To_Many_Update_Relationship_Test_1()
//        {
//            var propertyInfos = typeof(Applicant)
//                    .GetProperties()
//                    .Where(o => o.PropertyType.IsInterface && o.PropertyType.IsGenericType)
//                    .ToList();
//            Assert.IsTrue(propertyInfos.TrueForAll(o=> o.DeclaringType.ToString().Contains("Collection")));
//        }
//
//        private static Applicant Create()
//        {
//            var context = new CedarContext();
//            var applicant = context.Applicant.Create();
//
//            applicant.FirstName = "alaik";
//            var educationInfo = new EducationInfo
//                                    {
//                                        ApplicantId = applicant.ApplicantId,
//                                        College = "asdasd",
//                                        Level = EducationLevel.Bachelor
//                                    };
//            var educationInfo2 = new EducationInfo
//                                     {
//                                         ApplicantId = applicant.ApplicantId,
//                                         College = "12312",
//                                         Level = EducationLevel.Master
//                                     };
//            applicant.EducationInfos.Add(educationInfo);
//            applicant.EducationInfos.Add(educationInfo2);
//
//            context.Applicant.Add(applicant);
//            context.SaveChanges();
//            context.Commit();
//            return applicant;
//        }
//
//        private Applicant FindInContext(CedarContext context, Guid applicantId)
//        {
//            DbQuery<Applicant> dbQuery = context.Applicant.Include("EducationInfos");
//            Applicant first = dbQuery.First(o => o.ApplicantId == applicantId);
//            return first;
//        }
//
//        private Applicant FindById(Guid applicantId)
//        {
//            var context = new CedarContext();
//            DbQuery<Applicant> dbQuery = context.Applicant.Include("EducationInfos");
//            Applicant first = dbQuery.First(o => o.ApplicantId == applicantId);
//            return first;
//        }
//    }
}
