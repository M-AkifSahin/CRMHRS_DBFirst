using EF_DBFirst.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DBFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            CRMHRSDBEntities CRMHRSContext = new CRMHRSDBEntities();

            ShowMainMenu();

            #region Menüler

            void ShowMainMenu()
            {
                Console.WriteLine("Otel Rezervasyon Görüntüleme Sistemine Hoşgeldiniz");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1-Müşteri Bilgilerini Göster");
                Console.WriteLine("2-Otel Bilgilerini Göster");
                Console.WriteLine("3-Oda Bilgilerini Göster");
                Console.WriteLine("4-Rezervasyon Bilgilerini Göster");
                Console.WriteLine("5-Ödeme Bilgilerini Göster");
                Console.WriteLine(Environment.NewLine);


                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowAllCustomersScreen();
                }
                else if (cevap == 2)
                {
                    ShowAllHotelScreen();
                }
                else if (cevap == 3)
                {
                    ShowAllRoomScreen();
                }
                else if (cevap == 4)
                {
                    ShowAllReservationScrenn();
                }
                else if (cevap == 5)
                {
                    ShowAllPaymentScreen();
                }
            }

            void ShowCustomerDetailMenu()
            {
                Console.WriteLine("1-Anasayfaya Dön");
                Console.WriteLine("2-Geri Dön");
            }

            #endregion

            #region Ekranlar

            void ShowAllCustomersScreen()
            {
                Console.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                WriteCustomerList(GetAllCustomers());
                sw.Stop();

                Console.WriteLine($"İşlem Süresi: {sw.ElapsedMilliseconds}");

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Müşteri ID Giriniz");
                int Customerid = Convert.ToInt32(Console.ReadLine());
                WriteCustomerInfo(GetCustomersInfo(Customerid));

            }

            void ShowCustomerScreen()
            {
                Console.Clear();
                Console.WriteLine("Müşteri Id Giriniz");
                int customerID = Convert.ToInt32(Console.ReadLine());                
                Console.Clear();
                WriteCustomerInfo(GetCustomersInfo(customerID));

            }

            
            void ShowAllHotelScreen()
            {
                Console.Clear();
                WriteHotelList(GetAllHotels());

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Otel ID Giriniz");
                int HotelID = Convert.ToInt32(Console.ReadLine());
                WriteHotelInfo(GetHotelsInfo(HotelID));
            } 

            void ShowAllPaymentScreen()
            {
                Console.Clear();
                WritePaymentList(GetAllPayments());

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Ödeme ID Giriniz");
                int PaymentID = Convert.ToInt32(Console.ReadLine());
                WritePaymentInfo(GetPaymentsInfo(PaymentID));
            }

            void ShowAllReservationScrenn()
            {
                Console.Clear();
                WriteReservationList(GetAllReservations());

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Rezervasyon ID Giriniz");
                int Reservationid = Convert.ToInt32(Console.ReadLine());
                WriteReservationInfo(GetReservationsInfo(Reservationid));
            }

            void ShowAllRoomScreen()
            {
                Console.Clear();
                WriteRoomList(GetAllRooms());

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Oda ID Giriniz");
                int Roomid = Convert.ToInt32(Console.ReadLine());
                WriteRoomInfo(GetRoomsInfo(Roomid));
            }

            void ShowMainScrenn()
            {
                Console.Clear();
                ShowMainMenu();
            }
            #endregion

            #region Metotlar
            CustomerDTO GetCustomersInfo(int Customerid)
            {
                Console.Clear();
                var customer = CRMHRSContext.Customer.Where(q => q.id == Customerid).Include("Reservation").FirstOrDefault();

                CustomerDTO customerDTO = new CustomerDTO()
                {
                    id = customer.id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    UserName = customer.UserName,
                    Password = customer.Password,
                };

                return customerDTO;
            }

            HotelDTO GetHotelsInfo(int HotelID)
            {
                Console.Clear();
                var hotel = CRMHRSContext.Hotel.Where(q => q.id == HotelID).FirstOrDefault();

                HotelDTO hotelDTO = new HotelDTO()
                {
                    id = hotel.id,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    PhoneNumber = hotel.PhoneNumber,
                    Email = hotel.Email,
                    Website = hotel.Website,
                    Description = hotel.Description,
                };

                return hotelDTO;
            }

            PaymentDTO GetPaymentsInfo(int PaymentID)
            {
                Console.Clear();
                var payment = CRMHRSContext.Payment.Where(q => q.id == PaymentID).FirstOrDefault();

                PaymentDTO paymentDTO = new PaymentDTO()
                {
                    id = payment.id,
                    TotalPrice = payment.TotalPrice,
                    PaymentDate = payment.PaymentDate,
                    PaymentMethod = payment.PaymentMethod,
                   
                };

                return paymentDTO;
            }

            ReservationDTO GetReservationsInfo(int Reservationid)
            {
                Console.Clear();
                var reservation = CRMHRSContext.Reservation.Where(q => q.id == Reservationid).Include("Customer").Include("Room").FirstOrDefault();

                ReservationDTO reservationDTO = new ReservationDTO()
                {
                    id = reservation.id,
                    RoomId = reservation.RoomId,
                    CustomerId = reservation.CustomerId,
                    CheckInDate = reservation.CheckInDate,
                    CheckOutDate = reservation.CheckOutDate,
                    RoomType=reservation.Room.Type,
                    RoomNumber=reservation.Room.RoomNumber,
                    PricePerNight=reservation.Room.PricePerNight,
                    CustomerName=reservation.Customer.FirstName+ " " +reservation.Customer.LastName,
                    Email=reservation.Customer.Email,
                    PhoneNumber=reservation.Customer.PhoneNumber,
                };

                return reservationDTO;
            }

            RoomDTO GetRoomsInfo(int Roomid)
            {
                Console.Clear();
                var room = CRMHRSContext.Room.Where(q => q.id == Roomid).FirstOrDefault();

                RoomDTO roomDTO = new RoomDTO()
                {
                    id = room.id,
                    HotelId = room.HotelId,
                    Type = room.Type, 
                    RoomNumber = room.RoomNumber,
                    PricePerNight = room.PricePerNight,
                    Availability = room.Availability,
                   
                };

                return roomDTO;
            }

            void WriteCustomerInfo(CustomerDTO customerDTO)
            {
                Console.WriteLine("Müşteri Bilgileri");
                Console.WriteLine("------------------");
                Console.WriteLine("id: " + customerDTO.id);
                Console.WriteLine("Adı: " + customerDTO.FirstName);
                Console.WriteLine("Soyadı: " + customerDTO.LastName);
                Console.WriteLine("E-Posta: " + customerDTO.Email);
                Console.WriteLine("Telefon: " + customerDTO.PhoneNumber);
                Console.WriteLine("Kullanıcı Adı: " + customerDTO.UserName);
                Console.WriteLine("Şifre: " + customerDTO.Password);
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1-Ana Menüye Döne");
                Console.WriteLine("2-Geri Dön");
                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowMainScrenn();
                }
                else if (cevap == 2)
                {
                    ShowAllCustomersScreen();
                }
            }

            void WriteHotelInfo(HotelDTO hotelDTO)
            {
                Console.WriteLine("Otel Bilgileri");
                Console.WriteLine("------------------");
                Console.WriteLine("id: " + hotelDTO.id);
                Console.WriteLine("Adı: " + hotelDTO.Name);
                Console.WriteLine("Adres: " + hotelDTO.Address);
                Console.WriteLine("Telefon: " + hotelDTO.PhoneNumber);
                Console.WriteLine("E-Posta: " + hotelDTO.Email);
                Console.WriteLine("Web Adresi: " + hotelDTO.Website);
                Console.WriteLine("Açıklama: " + hotelDTO.Description);
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1-Ana Menüye Döne");
                Console.WriteLine("2-Geri Dön");
                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowMainScrenn();
                }
                else if (cevap == 2)
                {
                    ShowAllHotelScreen();
                }
            }

            void WritePaymentInfo(PaymentDTO paymentDTO)
            {
                Console.WriteLine("Ödeme Bilgileri");
                Console.WriteLine("------------------");
                Console.WriteLine("id: " + paymentDTO.id);
                Console.WriteLine("TotalPrice: " + paymentDTO.TotalPrice);
                Console.WriteLine("PaymentDate: " + paymentDTO.PaymentDate);
                Console.WriteLine("PaymentMethod: " + paymentDTO.PaymentMethod);
                
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1-Ana Menüye Döne");
                Console.WriteLine("2-Geri Dön");
                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowMainScrenn();
                }
                else if (cevap == 2)
                {
                    ShowAllPaymentScreen();
                }
            }

            void WriteReservationInfo(ReservationDTO reservationDTO)
            {
                Console.WriteLine("Rezervasyon Bilgileri");
                Console.WriteLine("------------------");
                Console.WriteLine("id: " + reservationDTO.id);
                Console.WriteLine("Oda Id: " + reservationDTO.RoomId);
                Console.WriteLine("Müşteri Id: " + reservationDTO.CustomerId);
                Console.WriteLine("Giriş Günü: " + reservationDTO.CheckInDate);
                Console.WriteLine("Çıkış Günü: " + reservationDTO.CheckOutDate);
                Console.WriteLine("Oda Tipi: "+reservationDTO.RoomType);
                Console.WriteLine("Oda Numarası: "+reservationDTO.RoomNumber);
                Console.WriteLine("Gecelik Fiyatı: "+reservationDTO.PricePerNight);
                Console.WriteLine("Müşteri Adı: "+reservationDTO.CustomerName);
                Console.WriteLine("Müşteri E-Posta: "+reservationDTO.Email);
                Console.WriteLine("Müşteri Telefon: "+reservationDTO.PhoneNumber);

                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1-Ana Menüye Döne");
                Console.WriteLine("2-Geri Dön");
                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowMainScrenn();
                }
                else if (cevap == 2)
                {
                    ShowAllReservationScrenn();
                }
            }

            void WriteRoomInfo(RoomDTO roomDTO)
            {
                Console.WriteLine("Oda Bilgileri");
                Console.WriteLine("------------------");
                Console.WriteLine("id: " + roomDTO.id);
                Console.WriteLine("Otel Id: " + roomDTO.HotelId);
                Console.WriteLine("Oda Numarası: " + roomDTO.RoomNumber);
                Console.WriteLine("Oda Tipi: " + roomDTO.Type);
                Console.WriteLine("Gecelik Fiyat: " + roomDTO.PricePerNight);
                Console.WriteLine("Müsaitlik Durumu: " + roomDTO.Availability);

                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("1-Ana Menüye Dön");
                Console.WriteLine("2-Geri Dön");
                int cevap = Convert.ToInt32(Console.ReadLine());

                if (cevap == 1)
                {
                    ShowMainScrenn();
                }
                else if (cevap == 2)
                {
                    ShowAllRoomScreen();
                }
            }

            void WriteCustomerList(List<CustomerDTO> customers)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($" MüşteriID --> {customer.id}\n Adı --> {customer.FirstName}\n Soyadı --> {customer.LastName}\n E-Posta --> {customer.Email}\n Telefon --> {customer.PhoneNumber}\n Kullanıcı Adı --> {customer.UserName}\n Şifre --> {customer.Password}");
                    Console.WriteLine("---------------------------------");
                }
            }

            void WriteHotelList(List<HotelDTO> hotels)
            {
                foreach (var hotel in hotels)
                {
                    Console.WriteLine($" OtelID --> {hotel.id}\n Adı --> {hotel.Name}\n Adres --> {hotel.Address}\n Telefon --> {hotel.PhoneNumber}\n E-Posta --> {hotel.Email}\n Web Adresi --> {hotel.Website}\n Açıklama --> {hotel.Description}");
                    Console.WriteLine("---------------------------------");
                }
            }

            void WritePaymentList(List<PaymentDTO> payments)
            {
                foreach (var payment in payments)
                {
                    Console.WriteLine($" Ödeme ID --> {payment.id}\n Toplam Tutar --> {payment.TotalPrice}\n Ödeme Günü --> {payment.PaymentDate}\n Ödeme Yöntemi --> {payment.PaymentMethod}");
                    Console.WriteLine("---------------------------------");
                }
            }

            void WriteReservationList(List<ReservationDTO> reservations)
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($" RezervasyonID --> {reservation.id}\n Oda Id --> {reservation.RoomId}\n Müşteri Id --> {reservation.CustomerId}\n Giriş Günü --> {reservation.CheckInDate}\n Çıkış Günü --> {reservation.CheckOutDate}");
                    Console.WriteLine("---------------------------------");
                }
            }

            void WriteRoomList(List<RoomDTO> rooms)
            {
                foreach (var room in rooms)
                {
                    Console.WriteLine($" Oda ID --> {room.id}\n Otel Id --> {room.HotelId}\n Oda Numarası --> {room.RoomNumber}\n Oda Tipi --> {room.Type}\n Gecelik Fiyatı --> {room.PricePerNight}\n Müsaitlik Durumu --> {room.Availability}");
                    Console.WriteLine("---------------------------------");
                }
            }

            List<CustomerDTO> GetAllCustomers()
            {
                List<CustomerDTO> customerList = new List<CustomerDTO>();
                var customers = CRMHRSContext.Customer.ToList();

                foreach (var customer in customers)
                {
                    customerList.Add(new CustomerDTO()
                    {
                        id = customer.id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber,
                        UserName = customer.UserName,
                        Password = customer.Password,
                    });
                }
                return customerList;
            }

            List<ReservationDTO> GetAllReservations()
            {
                List<ReservationDTO> reservationList = new List<ReservationDTO>();
                var reservations = CRMHRSContext.Reservation.ToList();

                foreach (var reservation in reservations)
                {
                    reservationList.Add(new ReservationDTO()
                    {
                        id = reservation.id,
                        RoomId = reservation.RoomId,
                        CustomerId = reservation.CustomerId,
                        CheckInDate = reservation.CheckInDate,
                        CheckOutDate = reservation.CheckOutDate,

                    });
                }
                return reservationList;
            }

            List<HotelDTO> GetAllHotels()
            {
                List<HotelDTO> hotelList = new List<HotelDTO>();
                var hotels = CRMHRSContext.Hotel.ToList();

                foreach (var hotel in hotels)
                {
                    hotelList.Add(new HotelDTO()
                    {
                        id = hotel.id,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        PhoneNumber = hotel.PhoneNumber,
                        Email = hotel.Email,
                        Website = hotel.Website,
                        Description = hotel.Description,
                    });
                }
                return hotelList;
            }

            List<RoomDTO> GetAllRooms()
            {
                List<RoomDTO> roomList = new List<RoomDTO>();
                var rooms = CRMHRSContext.Room.ToList();

                foreach (var room in rooms)
                {
                    roomList.Add(new RoomDTO()
                    {
                        id = room.id,
                        HotelId = room.HotelId,
                        RoomNumber = room.RoomNumber,
                        Type = room.Type,
                        PricePerNight = room.PricePerNight,
                        Availability = room.Availability,
                        
                    });
                }
                return roomList;
            }

            List<PaymentDTO> GetAllPayments()
            {
                List<PaymentDTO> paymentList = new List<PaymentDTO>();

                var payments = CRMHRSContext.Payment.ToList();

                foreach (var payment in payments)
                {
                    paymentList.Add(new PaymentDTO()
                    {
                        id = payment.id,
                        TotalPrice = payment.TotalPrice,
                        PaymentDate = payment.PaymentDate,
                        PaymentMethod = payment.PaymentMethod,
                    });
                }
                return paymentList;
            }

            #endregion
        }
    }
}
