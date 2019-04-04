using System.Threading.Tasks;
using TvMazeScrapper.Business.Connectors.TvMaze.Response;

namespace TvMazeScrapper.Business.Connectors
{
    public interface ITvMazeConnector
    {
        Task<TvMazeResponse> GetShow(int id);
    }
}