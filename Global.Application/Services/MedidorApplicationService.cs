using Global.Domain.Entities;
using Global.Domain.Interfaces;
using Global.Domain.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Application.Services
{
    public class MedidorApplicationService : IMedidorApplicationService
    {
        private readonly IMedidorRepository _medidorRepository;

        public MedidorApplicationService(IMedidorRepository medidorRepository)
        {
            _medidorRepository = medidorRepository;
        }

        public object DeletarMedidor(int id)
        {
            var medidor = _medidorRepository.ObterMedidor(id);
            if (medidor == null)
            {
                throw new Exception("Medidor não encontrado.");
            }

            _medidorRepository.DeletarMedidor(id);
            return new { Message = "Medidor deletado com sucesso.", MedidorId = id };
        }

        public MedidorEntity? EditarMedidor(int id, IMedidorDto medidorDto)
        {
            var medidor = _medidorRepository.ObterMedidor(id);
            if (medidor == null)
            {
                throw new Exception("Medidor não encontrado.");
            }

            medidor.data_medida = medidorDto.data_medida;
            medidor.valor_corrente = medidorDto.valor_corrente;
            medidor.valor_tensao = medidorDto.valor_tensao;
            medidor.valor_consumo = medidorDto.valor_consumo;
            medidor.MoradorId = medidorDto.MoradorId;

            _medidorRepository.EditarMedidor(medidor);
            return medidor;
        }

        public MedidorEntity? GetByid(int id)
        {
            var medidor = _medidorRepository.ObterMedidor(id);
            if (medidor == null)
            {
                throw new Exception("Medidor não encontrado.");
            }

            return medidor;
        }

        public MedidorEntity? InserirMedidor(IMedidorDto medidorDto)
        {
            medidorDto.Validator(); // Validações de negócio do DTO

            var novoMedidor = new MedidorEntity
            {
                data_medida = medidorDto.data_medida,
                valor_corrente = medidorDto.valor_corrente,
                valor_tensao = medidorDto.valor_tensao,
                valor_consumo = medidorDto.valor_consumo,
                MoradorId = medidorDto.MoradorId
            };

            _medidorRepository.InserirMedidor(novoMedidor);
            return novoMedidor;
        }

        public IEnumerable<MedidorEntity> ListarMedidores()
        {
            return _medidorRepository.ListarMedidores();
        }

        public object ObterMedidor(int id)
        {
            var medidor = _medidorRepository.ObterMedidor(id);
            if (medidor == null)
            {
                return new { Message = "Medidor não encontrado.", MedidorId = id };
            }

            return new
            {
                medidor.id,
                medidor.data_medida,
                medidor.valor_corrente,
                medidor.valor_tensao,
                medidor.valor_consumo,
                medidor.MoradorId
            };
        }
    }

}
