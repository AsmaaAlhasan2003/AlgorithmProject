namespace AlgorithmProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ����� �������
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ����� ���� ������� ��������
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // ����� ���� ��� Controllers
            app.MapControllers();

            // ����� ���� ������� ����� ������ �������� (����� �����������)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Algorithm}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
