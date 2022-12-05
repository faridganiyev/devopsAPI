namespace DevopsAPI.Data.Entities
{
    public class QuizVariant : BaseEntity
    {
        public string Variant { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
