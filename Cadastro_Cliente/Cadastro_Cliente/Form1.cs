using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_Cliente
{
    public partial class frmCadastroCliente : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=BD_CADASTRO;Trusted_Connection=True;";
        bool novo;
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            btnBuscar.Enabled = true;
            txbBuscaID.Enabled = true;
            txtName.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskCelular.Enabled = false;
            mskCEP.Enabled = false;
            mskTelefone.Enabled = false;
            txtEmail.Enabled = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            btnBuscar.Enabled = false;
            txbBuscaID.Enabled = false;
            txtName.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            mskCelular.Enabled = true;
            mskCEP.Enabled = true;
            mskTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtName.Focus();
            novo = true;


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                string sql = "INSERT INTO CLIENTE" +
                    "(NOME,ENDERECO,CEP,BAIRRO,CIDADE,UF,TELEFONE,CELULAR,EMAIL)"
                    + "VALUES('" + txtName.Text + "', '" + txtEndereco.Text + "', '" + mskCEP.Text + "', '" + txtBairro.Text + "', '" + txtCidade.Text + "', '" +
                    txtUF.Text + "', '" + mskTelefone.Text + "', '" + mskCelular.Text
                    + "', '" + txtEmail.Text + "' )";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cdastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sql = "UPDATE CLIENTE SET NOME='" + txtName.Text + "'," +
                    " ENDERECO='" + txtEndereco.Text + "'," +
                    " CEP='" + mskCEP.Text + "'," +
                    " BAIRRO='" + txtBairro.Text + "'," +
                    " CIDADE='" + txtCidade.Text + "'," +
                    " UF='" + txtUF.Text + "'," +
                    " TELEFONE='" +mskTelefone.Text + "'," +
                    " CELULAR='" + mskCelular.Text + "'," +
                    " EMAIL='" + txtEmail.Text + "', +" +
                    " WHERE ID='" + txtId.Text + "'";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(@sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            txbBuscaID.Enabled = true;
            btnBuscar.Enabled = true;
            txtName.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false; 
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskCelular.Enabled = false;
            mskTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtId.Text = "";
            txtName.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            mskCEP.Text = "";
            mskCelular.Text = "";
            mskTelefone.Text = "";
            txtEmail.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false; 
            btnExcluir.Enabled = false;
            txbBuscaID.Enabled = true;
            btnBuscar.Enabled = true;
            txtName.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtEmail.Enabled = false;
            txtUF.Enabled = false;
            mskCEP.Enabled = false;
            mskTelefone.Enabled = false;
            mskCelular.Enabled = false;
            txtId.Text = "";
            txtName.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtEmail.Text = "";
            mskCEP.Text = "";
            mskCelular.Text = "";
            mskTelefone.Text = "";

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM CLIENTE WHERE ID=" + txtId.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();

            }
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = false;
            txbBuscaID.Enabled = true;
            btnBuscar.Enabled = true;
            txtName.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtEmail.Enabled = false;
            mskCEP.Enabled = false;
            mskCelular.Enabled = false;
            mskTelefone.Enabled = false;
            txtId.Text = "";
            txtName.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtEmail.Text = "";
            mskCelular.Text = "";
            mskCEP.Text = "";
            mskTelefone.Text = "";




        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CLIENTE WHERE ID=" + txbBuscaID.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    btnNovo.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txbBuscaID.Enabled = false;
                    btnBuscar.Enabled = false;
                    txtName.Enabled = true;
                    txtEndereco.Enabled = true;
                    txtBairro.Enabled = true;
                    txtCidade.Enabled = true;
                    txtUF.Enabled = true;
                    mskCEP.Enabled = true;
                    mskTelefone.Enabled = true;
                    mskCelular.Enabled = true;
                    txtEmail.Enabled = true;
                    txtName.Focus();
                    txtId.Text = reader[0].ToString();
                    txtName.Text = reader[1].ToString();
                    txtEndereco.Text = reader[2].ToString();
                    txtBairro.Text = reader[3].ToString();
                    txtCidade.Text = reader[4].ToString();
                    txtUF.Text = reader[5].ToString();
                    txtEmail.Text = reader[6].ToString();
                    mskCEP.Text = reader[7].ToString();
                    mskCelular.Text = reader[8].ToString();
                    mskTelefone.Text = reader[9].ToString();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado com o ID informado");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            txbBuscaID.Text = "";
            
                   
            }

        }
    }


  