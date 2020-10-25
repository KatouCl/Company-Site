using CompanySite.Domain.Repositories.Abstract;

namespace CompanySite.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository ServiceItems { get; set; }
        public IFeedBackRepository FeedBack { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, IFeedBackRepository feedBackRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            FeedBack = feedBackRepository;
        }
    }
}
