using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymCenter.Core;
using GymCenter.Core.Domain.Entities;
using GymCenter.ViewModels;

namespace GymCenter.Commands.ServiceCommands
{
    public class SaveServiceCommand : BaseServiceCommand
    {
        public SaveServiceCommand(SaveServiceViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            var service = new Service
            {
                Id = _saveServiceViewModel.ServiceModel.Id,
                Name = _saveServiceViewModel.ServiceModel.Name,
                Price = _saveServiceViewModel.ServiceModel.Price
            };

            if (service.Id == 0)
                Kernel.DB.ServiceRepository.Add(service);
            else
                Kernel.DB.ServiceRepository.Update(service);

            _saveServiceViewModel.Window.Close();
        }
    }
}
