using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Cedar.WebPortal.Data
{
    using Cedar.WebPortal.Domain;

    using NHibernate;


    public class GalleryMapOverride : ClassMapping<Gallery>
    {
        public GalleryMapOverride()
        {
            Bag(
                x => x.Attachments,
                collectionMapping =>
                {
                    collectionMapping.Table("AttachmentToGallery");
                    collectionMapping.Cascade(Cascade.None);
                    collectionMapping.Key(k => k.Column("GalleryId"));
                },
                map => map.ManyToMany(
                    p => p.Column("AttachmentId")));
        }

    }

    public class LocationMapOverride : ClassMapping<Location>
    {
        public LocationMapOverride()
        {
            Mutable(true);
        }
    }

    public class NewsMappingOverride : ClassMapping<News>
    {
        public NewsMappingOverride()
        {
            Property(x => x.Contents, map => map.Type(NHibernateUtil.StringClob));
        }


    }

    public class ApplicantMapOverride : ClassMapping<Applicant>
    {
        public ApplicantMapOverride()
        {

            Bag(x => x.EducationInfos, collectionMapping =>
            {

                collectionMapping.Cascade(Cascade.All);
                collectionMapping.Key(k => k.Column("ApplicantId"));
            },
                    map => map.OneToMany(p =>
                    {
                        p.Class(typeof(EducationInfo));
                    }));
        }
    }


}
