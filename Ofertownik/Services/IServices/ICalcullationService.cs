using System.Threading.Tasks;

namespace Ofertownik.Services.IServices
{
    public interface ICalcullationService
    {
        Task<double> CalcullateMachineWorkPerMinutePrice(string userId, int machineId, int minutes);
        Task<double> CalcullateMaterialMargin(string userId);
        Task<double> CalcullateProductMargin(string userId);
        Task<double> CalcullateWorkerWorkPerMinutePrice(string userId, int minutes);
        Task<double> CalculateMaterialPrice(int materialId, string userId, int height, int width);
        Task<double> CallculateMarkingPrice(string userId,
                                                       int productId,
                                                       int materialId,
                                                       int machineId,
                                                       int minutes,
                                                       int height,
                                                       int width);

    }
}
