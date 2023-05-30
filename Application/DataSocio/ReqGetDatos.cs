using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataSocio
{
	public class ReqGetDatos : IRequest<ResGetDatos>
	{
		public string str_cedula { get; set; } = string.Empty;
	}
}
