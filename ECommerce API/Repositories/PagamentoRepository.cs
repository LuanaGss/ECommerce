using ECommerce_API.Context;
using ECommerce_API.DTO;
using ECommerce_API.Interfaces;
using ECommerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_API.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly EcommerceContext _context;
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pagamento pagamento)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.Status = pagamento.Status;
            pagamentoEncontrado.Data = pagamento.Data;

            _context.SaveChanges();
         
        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);
        }

        public void Cadastrar(CadastrarPagamentoDto pagamento)
        {

            Pagamento pagamentoCadastro = new Pagamento
            {
                IdPedido = pagamento.IdPedido,
                FormaPagamento = pagamento.FormaPagamento,
                Status = pagamento.Status,
                Data = pagamento.Data
            };

            _context.Pagamentos.Add(pagamentoCadastro);

            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if(pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.IdPedidoNavigation).ToList();
        }
    }
}
