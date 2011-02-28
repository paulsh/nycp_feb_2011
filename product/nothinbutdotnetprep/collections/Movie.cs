using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IComparable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public static bool IsAscending { get; set; }
        public static SortMethod SortOrder { get; set; }
        
        public int CompareTo(Movie other)
        {
            switch (SortOrder)
            {
                case SortMethod.title:
                    if (IsAscending)
                        return string.Compare(this.title, other.title);
                    return string.Compare(other.title, this.title);

                case SortMethod.date_published:
                    if (IsAscending)
                        return DateTime.Compare(this.date_published, other.date_published);
                    return DateTime.Compare(other.date_published, this.date_published);
                case SortMethod.rating:
                    if (IsAscending)
                    {
                        if (this.rating > other.rating) return 1;
                        if (this.rating == other.rating) return 0;
                        return -1;
                    }
                    if (this.rating > other.rating) return -1;
                    if (this.rating == other.rating) return 0;
                    return 1;
                case SortMethod.ratingAndDatePublished:
                    if (IsAscending)
                    {
                        if (this.rating > other.rating) return 1;
                        if (this.rating == other.rating)
                        {
                            return DateTime.Compare(this.date_published, other.date_published);
                        }
                        return -1;
                    }
                    if (this.rating > other.rating) return -1;
                    if (this.rating == other.rating)
                    {
                        return DateTime.Compare(other.date_published, this.date_published);
                    }
                    return 1;
            }
            return 1;
        }

    }

    public enum SortMethod
    {
        title = 0,
        ratingAndDatePublished = 1,
        rating = 2,
        date_published = 3,
    }
}