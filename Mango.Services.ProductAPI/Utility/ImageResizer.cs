
namespace Mango.Services.ProductAPI.Utility
{
	public static class ImageResizer
	{

		public static void ResizeImage(string path)
		{
			using(Image image = Image.Load(path))
			{
				image.Mutate(x => x.Resize(500, 430));	
				image.Save(path);
			}			
		}
		
	}
    
}

