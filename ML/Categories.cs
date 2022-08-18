namespace ML
{
    public class Categories
    {
        public int Id { get; set; }
        public int Ref_id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<object> categories { get; set; }
    }
}