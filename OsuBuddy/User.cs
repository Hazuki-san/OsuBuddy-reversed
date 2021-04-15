using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OsuBuddy
{
	// Token: 0x020000B9 RID: 185
	public class User
	{
		// Token: 0x060004BA RID: 1210 RVA: 0x00017DD8 File Offset: 0x00017DD8
		public User(string username, string password)
		{
			this.username = "user";
			this.password = "";
			this.client = "OsuBuddy";
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00017E34 File Offset: 0x00017E34
		private bool connectToServer()
		{
			try
			{
				this.clientSocket.Connect(this.serverAddress);
			}
			catch (SocketException ex)
			{
				Console.WriteLine(ex.Message);
				this.loginFailureStatus = "Server error - Couldn't connect to the TaikoBuddy server, please try again later.";
				return false;
			}
			return true;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000047CF File Offset: 0x000047CF
		public bool isSubscribed()
		{
			return true;
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x000047CF File Offset: 0x000047CF
		public bool login()
		{
			return true;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00017E80 File Offset: 0x00017E80
		private void sendToServer(string toSend)
		{
			int byteCount = Encoding.ASCII.GetByteCount(toSend);
			byte[] bytes = Encoding.ASCII.GetBytes(toSend);
			byte[] bytes2 = BitConverter.GetBytes(byteCount);
			if (this.clientSocket.Connected)
			{
				this.clientSocket.Send(bytes2);
				this.clientSocket.Send(bytes);
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00017ED4 File Offset: 0x00017ED4
		private string readFromServer()
		{
			byte[] array = new byte[4];
			this.clientSocket.Receive(array);
			byte[] array2 = new byte[BitConverter.ToInt32(array, 0)];
			this.clientSocket.Receive(array2);
			return Encoding.ASCII.GetString(array2);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000047D2 File Offset: 0x000047D2
		public string getUsername()
		{
			return this.username;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000047DA File Offset: 0x000047DA
		public string getSubscriptionExpirationDate()
		{
			return "never";
		}

		// Token: 0x04000492 RID: 1170
		private IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("68.183.58.197"), 4343);

		// Token: 0x04000493 RID: 1171
		private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		// Token: 0x04000494 RID: 1172
		public string loginFailureStatus;

		// Token: 0x04000495 RID: 1173
		private string username;

		// Token: 0x04000496 RID: 1174
		private string password;

		// Token: 0x04000497 RID: 1175
		private string client;

		// Token: 0x04000498 RID: 1176
		private string subscriptionExpirationDate;
	}
}
