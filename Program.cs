using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perbaikan
{
    class Program
    {

        static void menu()
        {
            Console.WriteLine("{0,-40}{1,40}", "1 - Penarikan", "Info Saldo - 4");
            Console.WriteLine("{0,-40}{1,40}", "2 - Setoran", "Pembelian Pulsa - 5");
            Console.WriteLine("{0,-40}{1,40}", "3 - Transfer", "Ganti Password - 6");
        }


        static void login(ref string nama, ref string pass)
        {
            int i;
            string id, sandi;
            do
            {

                Console.WriteLine("\n\t\t\t\tSilahkan Login");
                i = 0;
                Console.Write("\n\n\n\t\t\tmasukkan ID \t\t: ");
                id = Console.ReadLine();
                Console.Write("\t\t\tmasukkan password \t: ");
                sandi = Console.ReadLine();

                if (id == nama)
                {
                    i++;
                    if (sandi == pass)
                        i++;
                }
                if (i != 2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\tID atau password yang anda masukkan salah!!!!");
                }
            } while (i != 2);
        }


        static void  penarikan(ref long saldo,ref long penarikan)
        {
            
                bool z;
                
                do
                {
                    z = true;
                try
                {
                    Console.Write("\n\n\tMasukkan Jumalah Yang Anda Inginkan : ");
                    Console.Write("RP. ");
                    penarikan = Convert.ToInt64(Console.ReadLine());

                    if (penarikan < 0)
                        throw new Exception("Tidak Boleh lebih kecil dari \' 0 \' ");
                }
                catch (Exception e)
                {
                    z=false;
                    
                    Console.WriteLine("\t\t Error : "+e.Message);
                }
                }while(z==false);
               
            if (saldo >= penarikan)
            {
                saldo = saldo - penarikan;
                Console.Write("\n\t\tApakakah Anda Ingin Mencetak struk?(Y/T) : ");
                if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
                {
                    Console.Clear();
                    Console.WriteLine("Penarikan Tunai Sebesar : Rp. " + penarikan);
                    Console.WriteLine("\n\nSaldo : Rp. " + saldo);
                    Console.WriteLine("\nTerimakasih");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\t\tJumlah Saldo Anda Tidak Mencukupi!!");
            }
        }


        static void setoran(ref long saldo, ref long setoran)
        {
            bool z;
            do
            {
                z = true;
                try
                {
                    Console.Write("\n\t\tMasukkan Jumlah Setoran : Rp. ");
                    setoran = Convert.ToInt32(Console.ReadLine());
                    if (setoran < 0)
                    {
                        Console.Clear();
                        throw new Exception("Setoran Harus Lebih Besar Dari Rp. 0.-");
                    }
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\n\t\tError : " + e.Message);
                }
            } while (z==false);
            saldo = saldo + setoran;
            Console.Write("\n\t\tApakakah Anda Ingin Mencetak struk?(Y/T) : ");
            if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
            {
                Console.Clear();
                Console.WriteLine("Setoran Tunai Sebesar : Rp. " + setoran);
                Console.WriteLine("\n\nSaldo : Rp. " + saldo);
                Console.WriteLine("\nTerimakasih");
            }
        }


        static void tran(ref long saldo, ref long penarikan, ref int bt)
        {
            bt = 0;
            bool z;
            string transfer = "";
            
            Console.WriteLine("1 - Sesama Bank");
            Console.WriteLine("2 - Bank Lain");
            do
            {
                z = true;
                try
                {
                    Console.Write("Masukkan Pilihan 1-2 : ");
                    int t = Convert.ToInt32(Console.ReadLine());
                    if (t < 1 || t > 2)
                        throw new Exception("Perintah tidak dikenali, masukkan 1 - 2 ");
                    if (t == 2)
                        bt = 6000;
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\nError : " + e.Message);
                }
            } while (z == false);

            
                Console.Clear();
                do
                {
                    z = true;
                    try
                    {
                        Console.Write("\tMasukkan User Yang Dituju : ");
                        transfer = Console.ReadLine();
                        Console.Write("\tJumlah yang akan di transfer : Rp. ");
                        penarikan = Convert.ToInt32(Console.ReadLine());

                        if (transfer.Trim().Length <= 0)
                            throw new Exception("user tidak boleh kosong");
                        else if (penarikan < 0)
                            throw new Exception("Transfer tidak boleh di bawah \'0\'");
                    }
                    catch (Exception e)
                    {
                        z = false;
                        Console.Clear();
                        Console.WriteLine("\n\t\tError : " + e.Message+"\n");
                    }
                } while (z == false);
                

                Console.Clear();
                Console.WriteLine("user yang dituju : " + transfer);
                Console.WriteLine("Jumlah Transfer : Rp. " + penarikan);
                Console.WriteLine("Biaya Transfer : Rp. " + bt);
                Console.Write("Apakah data sudah benar? (Y/T) : ");

                if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
                {
                    if (saldo >= penarikan)
                    {


                        saldo = saldo - (penarikan + bt);
                        Console.Write("\n\t\tApakakah Anda Ingin Mencetak struk?(Y/T) : ");
                        if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
                        {
                            Console.Clear();
                            Console.WriteLine("Transfer Kepada : " + transfer);
                            Console.WriteLine("Transfer Sebesar : Rp. " + penarikan);
                            Console.WriteLine("\n\nSaldo : Rp. " + saldo);
                            Console.WriteLine("\nTerimakasih");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo Anda Tidak Mencukupi Untuk Melakukan Transaksi ini!!");
                    
                }
            }
        }

        
        static void isiPulsa(ref long saldo, ref long penarikan)
        {
            bool z;
            string nohp="";
            int pulsa=0, bayar=0;
            Console.WriteLine("1 - Isi Ulang Pulsa");
            Console.WriteLine("2 - Listrik Prabayar");
            do
            { z=true;
            try
            {
                Console.Write("Masukkan Pilihan : ");
                bayar = Convert.ToInt32(Console.ReadLine());

                if (bayar < 1 || bayar > 2)
                    throw new Exception("Perintah Tidak Dikenali, Masukkan 1-2");

            }
            catch (Exception e)
            {
                z = false;
                Console.WriteLine("\n\t\tError : " + e.Message);
            }
            } while (z==false);

            Console.Clear();
            if (bayar == 1)
            {
                Console.Clear();
                Console.Write("Masukkan nomor : ");
            }
            else
            {
                Console.Clear();
                Console.Write("Masukkan ID rekening Anda : ");
            }

            do
            {
                z = true;
                try
                {
                    nohp = Console.ReadLine();
                    if (nohp.Trim().Length <= 0)
                        throw new Exception("Tidak Boleh Kosong!!");
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\n\t\tError : " + e.Message);
                }
            } while (z == false);
            Console.WriteLine("jumlah pulsa : ");
            Console.WriteLine("1 - Rp. 10,000.-");
            Console.WriteLine("2 - Rp. 20,000.-");
            Console.WriteLine("3 - Rp. 30,000.-");
            Console.WriteLine("4 - Rp. 50,000.-");
            Console.WriteLine("5 - Rp. 100,000.-");
            Console.WriteLine("6 - Rp. 500,000.-");
            Console.WriteLine("7 - Rp. 1,000,000.-");
            do
            {
                z=true;
                try
                {
                    Console.Write("Masukkan Pilihan Pulsa : ");
                    pulsa = Convert.ToInt32(Console.ReadLine());
                    if (pulsa < 1 || pulsa > 7)
                        throw new Exception("Perintah Tidak Dikenali, Masukkan 1-7");
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\n\t\tError : " + e.Message);
                }
            } while (z==false);


            if (pulsa == 1)
            {
                penarikan = 10000;
            }

            else if (pulsa == 2)
            {
                penarikan = 20000;
            }

            else if (pulsa == 3)
            {
                penarikan = 30000;
            }


            else if (pulsa == 4)
            {
                penarikan = 50000;
            }


            else if (pulsa == 5)
            {
                penarikan = 100000;
            }


            else if (pulsa == 6)
            {
                penarikan = 500000;
            }


            else
            {
                penarikan = 1000000;
            }



            if (saldo >= penarikan)
            {
                Console.Write("Apakah Anda Yakin Melakukan Pembelian Pulsa Sebesar Rp. " + penarikan + ".- \nkepada " + nohp + "(Y/T)");
                if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
                    saldo = saldo - penarikan;
                Console.Write("\n\t\tApakakah Anda Ingin Mencetak struk?(Y/T) : ");
                if (Console.ReadKey().KeyChar.ToString().ToUpper() != "T")
                {
                    Console.Clear();
                    Console.WriteLine("Denom : Rp. " + penarikan);
                    Console.WriteLine("Jumlah : Rp. " + penarikan);
                    Console.WriteLine("\n\nSaldo : Rp. " + saldo);
                    Console.WriteLine("\nTerimakasih");
                }
            }
            else
                Console.WriteLine("Saldo Anda tidak Mencukupi Untuk Melakukan Transaksi ini!!");
        }


        static void gantiPin(ref string pass)
        {
            string sandilama="", sandibaru="", ulang="";
            bool z;
            do
            {
                z = true;
                try
                {
                    Console.Write("Masukkan Password Lama : ");
                    sandilama = Console.ReadLine();
                    Console.Write("Masukkan Password Baru : ");
                    sandibaru = Console.ReadLine();
                    Console.Write("Konfirmasi Password Baru : ");
                    ulang = Console.ReadLine();
                    if (sandibaru.Trim().Length <= 0)
                        throw new Exception("Sandi Wajib Diisi!!");
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\n\t\tError : " + e.Message);
                }
            } while (z == false);

            if (sandilama == pass)
            {
                if (ulang == sandibaru)
                {
                    pass = sandibaru;
                    Console.WriteLine("Password Berhasil Diubah");
                }
                else
                {
                    Console.WriteLine("\n\t\t  Konfirmasi Password Tidak Sama!!!");
                    Console.WriteLine("\t\t\tPassword Gagal Diubah!!!");
                }
            }
            else
            {
                Console.WriteLine("\n\t\t  Password Yang Anda Masukkan Salah!!!");
                Console.WriteLine("\t\t\tPassword Gagal Diubah!!!");
            }
        }
        

        struct data
        {
            public string nama,pass;
            public long saldo;
            public long penarikan;
            public long setoran;
        }
        static void Main(string[] args)
        {
            data user;

            int p=0, bt = 0,pilihan=0;

            string ulang="";
            bool z;

            user.penarikan = 0;
            user.setoran = 0;
            user.saldo = 0;
            user.nama = "";
            user.pass = "";

            Console.WriteLine("\n\n\t\t\t1. DAFTAR");
            Console.WriteLine("\t\t\t2. LOGIN");
            Console.WriteLine("\t\t\t3. KELUAR");
            do
            {
                z = true;
                try
                {
                    Console.Write("\t\t\tmasukkan pilihan : ");
                    pilihan = Convert.ToInt32(Console.ReadLine());
                    if (pilihan < 1 || pilihan > 3)
                        throw new Exception("Perintah Tidak Dikenali !!!");
                }
                catch (Exception e)
                {
                    z = false;
                    Console.WriteLine("\n\t\tError : " + e.Message);
                }
            } while (z == false);

            
            
                if(pilihan==1)
                {
                    do
                    {
                        Console.Clear();
                        do
                        {
                            do
                            {
                                z = true;
                                try
                                {
                                    Console.Write("\n\n\n\t\tmasukkan ID yang anda inginkan \t: ");
                                    user.nama = Console.ReadLine();
                                    Console.Write("\t\tmasukkan kata sandi \t\t: ");
                                    user.pass = Console.ReadLine();
                                    Console.Write("\t\tmasukkan ulang kata sandi \t: ");
                                    ulang = Console.ReadLine();
                                    if (user.nama.Trim().Length <= 0)
                                        throw new Exception("ID Wajib Diisi!!");
                                    else if (user.pass.Trim().Length <= 0)
                                        throw new Exception("Kata Sandi Wajib Diisi!!");
                                }
                                catch (Exception e)
                                {
                                    z = false;
                                    user.nama = "";
                                    user.pass = "";
                                    Console.Clear();
                                    Console.WriteLine("\n\t\tError : " + e.Message);
                                }
                            } while (z == false);


                            if (ulang != user.pass)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\t\t\tKonfirmasi Password Salah!!");
                                Console.WriteLine("\t\tPastikan Kata Sandi di masukkan dengan benar 2 kalinya");
                            }
                        } while (ulang != user.pass);

                        do
                        {
                            z = true;
                            try
                            {
                                Console.Write("\t\tJumlah Saldo Awal \t\t: RP  ");
                                user.saldo = Convert.ToInt64(Console.ReadLine());
                                if (user.saldo < 0)
                                    throw new Exception("saldo minimal 0!!!");
                            }
                            catch (Exception e)
                            {
                                z = false;
                                user.saldo = 0;
                                Console.WriteLine("\n\t\tError : " + e.Message);
                            }
                        } while (z == false);

                        Console.Clear();
                        Console.WriteLine("\n\n\t\tID\t\t : " + user.nama);
                        Console.WriteLine("\t\tKata Sandi\t : " + user.pass);
                        Console.WriteLine("\t\tSaldo Awal\t : Rp. " + user.saldo);

                        Console.Write("\n\tApakah Anda Yakin Data Sudah Benar (Y/T) : ");
                    } while (Console.ReadKey().KeyChar.ToString().ToUpper() == "T");
                    Console.Clear();
                }



                else if (pilihan == 2)
                {
                    Console.Clear();
                    user.nama = "ilham";
                    user.pass = "maulana";
                    user.saldo = (long)1000000;

                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\t\tTerimakasih");
                    Console.ReadKey();
                }




            

            if (pilihan == 1 || pilihan == 2)
            {
                do
                {
                    Console.Clear();
                    login(ref user.nama, ref user.pass);

                    Console.Clear();


                    do
                    {
                        z = true;
                        try
                        {
                            menu();
                            Console.Write("\n\n\t\t\tMasukkan Pilihan(1-6) = ");
                            p = Convert.ToInt32(Console.ReadLine());
                            if (p < 1 || p > 6)
                                throw new Exception("Perintah tidak dikenali (Pastikan Pilihan (1-6)!!!!");
                        }
                        catch (Exception e)
                        {
                            z = false;
                            p = 0;
                            Console.Clear();
                            Console.WriteLine("\n\t\tError : " + e.Message + "\n");
                        }
                    } while (z == false);

                    Console.Clear();


                    if (p == 1)

                        penarikan(ref user.saldo, ref user.penarikan);


                    else if (p == 2)

                        setoran(ref user.saldo, ref user.setoran);


                    else if (p == 3)

                        tran(ref user.saldo, ref user.penarikan, ref bt);


                    else if (p == 4)
                    {

                        Console.Write("Sisa Saldo Anda Saat Ini Adalah : ");
                        Console.WriteLine("RP. " + user.saldo);
                    }

                    else if (p == 5)

                        isiPulsa(ref user.saldo, ref user.penarikan);


                    else if (p == 6)

                        gantiPin(ref user.pass);


                    else
                        Console.WriteLine("Perintah Tidak Dikenali !!!!");


                    Console.Write("\n\n\n\t\tApakah Ingin Melakukan Transaksi Lain (Y/T) : ");
                } while (Console.ReadKey().KeyChar.ToString().ToUpper() != "T");
            }
        }
    }
}
