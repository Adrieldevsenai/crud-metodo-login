using ExoApi.Contexts;
using ExoApi.Domains;
using System.Security.Cryptography.X509Certificates;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoApiContext _ctx;
        private object _context;

        public ProjetoRepository( ExoApiContext ctx )
        {
            _ctx = ctx;
        }

        public List<Projeto> Listar()
        {
            return _ctx.Projetos.ToList();

        }

        public void Criar(Projeto projeto) 
        {

            _context.Projetos.Add( projeto );

            _context.SaveChanges();

        }
        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projeto = _context.Projetos.Find(id);
        }

            if (projeto.NomeDoProjeto != null)
            {
                projeto1.NomeDoProjeto = projeto.NomeDoProjeto;
            }
                    if (projeto1.Area != null)
            {
                        projeto1.Area = projeto.Area;
            }
                    if (projeto.Status != null)
            {
                        projeto1.Status = projeto.Status;
            }

                    _context.Projetos.Update(projeto1)

                    _context.SaveChanges();
                

                        public Projeto BuscarPorId(int id)
                

                    return _context.Projetos.Find(id);
                    {


                    }
               
                    public void Deletar(int id)
                    {
                        Projeto projeto = _context.Projetos.Find(id);

                        _context.Projeto.Remove(projeto);

                        _context.SaveChanges();
                    }
                }
            }
        }
