using Grpc.Net.Client;
using grpcServer.Protos;

namespace WinFormsClient
{
    public partial class Form1 : Form
    {
        GrpcChannel channel;
        ProductService.ProductServiceClient client;

        public Form1()
        {
            InitializeComponent();
            channel = GrpcChannel.ForAddress("https://localhost:7296/");
            client = new ProductService.ProductServiceClient(channel);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var response = client.AddNewProduct(new RequestAddProductDto()
            {
                Brand = textBrand.Text,
                Name = textName.Text,
                Price = int.Parse(textPrice.Text)
            });

            if (response.IsSuccess)
            {
                MessageBox.Show("New product was successfully added");
            }
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            var response = client.GetAllProduct(new RequestAllProduct()
            {
                Page = 1,
                PageSize = 10,
            });

            dataGridView1.DataSource = response.Items;

        }
    }
}