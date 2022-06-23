using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FJU.Inventario.Application.Commands.RemoveProduct
{
    public class RemoveProductParams : IRequest<RemoveProductResponse>
    {
        public string? Id { get; set; }
    }
}
