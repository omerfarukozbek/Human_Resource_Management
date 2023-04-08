namespace HR_T3.Application.Helpers
{
    public static class ImageHelper
    {
        public static bool HasImageExtension(this string source)
        {
            return (source.EndsWith(".png") || source.EndsWith(".jpg") || source.EndsWith(".jpeg"));
        }
    }
}
