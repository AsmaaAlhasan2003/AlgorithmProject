namespace AlgorithmProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ≈÷«›… «·Œœ„« 
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ≈⁄œ«œ »Ì∆… «· ÿÊÌ— Ê«·≈‰ «Ã
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            //  ›⁄Ì· Ã„Ì⁄ «·‹ Controllers
            app.MapControllers();

            //  ⁄œÌ· ‰ﬁÿ… «·»œ«Ì… · ﬂÊ‰ «·’›Õ… «·—∆Ì”Ì… (ﬁ«∆„… «·ŒÊ«—“„Ì« )
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Algorithm}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
