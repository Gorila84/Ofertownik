using Ofertownik.Repositories.IRpositories;
using Ofertownik.Services.IServices;
using System.Threading.Tasks;

namespace Ofertownik.Services
{
    public class CalcullationService : ICalcullationService
    {
        private readonly ICalcullationSettingsRepository _settingsRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IProductRepository _product;

        public CalcullationService(ICalcullationSettingsRepository settingsRepository,
                                   IMachineRepository machineRepository,
                                   IMaterialRepository materialRepository,
                                   IProductRepository product)
        {
            _settingsRepository = settingsRepository;
            _machineRepository = machineRepository;
            _materialRepository = materialRepository;
            _product = product;
        }

        public async Task<double> CalcullateMachineWorkPerMinutePrice(string userId, int machineId, int minutes)
        {
            var machine = await _machineRepository.GetMachine(machineId, userId);
            var settings = await _settingsRepository.GetCalcullationSettings(userId);
            double machinePower = machine.MachinePower / 1000;
            double machineWorkingPricePerHour = machinePower * settings.EnergyPrice;
            double machineWorkingPrice = (machineWorkingPricePerHour / 60) * minutes;

            return machineWorkingPrice;
        }

        public async Task<double> CalcullateMaterialMargin(string userId)
        {
            var materialMarginSetting = await _settingsRepository.GetCalcullationSettings(userId);
            double materialMargin = (materialMarginSetting.MaterialMargin + 100) / 100;

            return materialMargin;
        }

        public async Task<double> CalcullateProductMargin(string userId)
        {
            var productMarginSettings = await _settingsRepository.GetCalcullationSettings(userId);
            double productMargin = (productMarginSettings.ProductMargin + 100) / 100;
            return productMargin;
        }

        public async Task<double> CalcullateWorkerWorkPerMinutePrice(string userId,  int minutes)
        {
            var getWorkerPricePerHour = await _settingsRepository.GetCalcullationSettings(userId);
            double oneMinuteWorkerPrice = (getWorkerPricePerHour.WorkerHourPrice / 60) * minutes;
            return oneMinuteWorkerPrice;
            
        }

        public async Task<double> CalculateMaterialPrice(int materialId, string userId, int height, int width)
        {
            var material = await _materialRepository.GetMaterial(materialId, userId);

            double materialPrice = (material.PurchasePrice / (material.Height * material.Width)) * await CalcullateMaterialMargin(userId);

            double priceForUseMaterial = (height * width) * materialPrice;

            return priceForUseMaterial;
        }


        public async Task<double> CallculateMarkingPrice(string userId,
                                                       int productId,
                                                       int materialId,
                                                       int machineId,
                                                       int minutes, 
                                                       int height,
                                                       int width)
        {
            var product = await _product.GetProduct(productId, userId);
            var material = await _materialRepository.GetMaterial(materialId, userId);
            double markingPrice = await CalcullateWorkerWorkPerMinutePrice(userId, minutes) +
                                  await CalculateMaterialPrice(materialId, userId, height, width) +
                                  ( product.PurchasePrice * await CalcullateProductMargin(userId)) +
                                  await CalcullateMachineWorkPerMinutePrice(userId,machineId,minutes);
            return markingPrice;
        }
    }
}
