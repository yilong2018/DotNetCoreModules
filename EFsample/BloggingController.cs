namespace EFsample{
    public class BloggingController{
        private readonly BloggingContext _context;
        public BloggingController(BloggingContext context)
        {
            _context = context;            
        }
    }
}