namespace BlogCw.Models
{
    public class AdminDashboardViewModel
    {
        public int AllPostsCount { get; set; }
        public int TotalUpvotes { get; set; }
        public int TotalDownvotes { get; set; }
        public int TotalComments { get; set; }
        public int MonthPostsCount { get; set; }
        public int MonthUpvotes { get; set; }
        public int MonthDownvotes { get; set; }
        public int MonthComments { get; set; }
    }
}