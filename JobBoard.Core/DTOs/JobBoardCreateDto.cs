namespace JobBoard.Core.DTOs
{
    public class JobBoardCreateDto
    {
        public string JobBoardName { get; set; }

        public bool IsOnlineApply { get; set; }

        public bool IsEmailApply { get; set; }
    }
}
