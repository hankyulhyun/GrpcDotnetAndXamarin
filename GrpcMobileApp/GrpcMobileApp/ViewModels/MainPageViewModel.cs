using Grpc.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

namespace GrpcMobileApp.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string welcomeText;
        public string WelcomeText
        {
            get { return this.welcomeText; }
            set { welcomeText = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WelcomeText")); }
        }

        public MainPageViewModel()
        {
            this.WelcomeText = "Welcome MVVM";

            Channel channel = new Channel("10.0.2.2", 5002, ChannelCredentials.Insecure);
            var client = new GrpcGreeter.Greeter.GreeterClient(channel);

            var reply = client.SayHello(new GrpcGreeter.HelloRequest { Name = "Xamarin Client" });

            this.WelcomeText = reply.Message;
        }
    }
}
