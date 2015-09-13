using Cirrious.MvvmCross.Plugins.Messenger;

namespace WeakEvents.Services
{
    public class TimerMessage : MvxMessage
    {
        public int TimerEventId { get; private set; }

        public TimerMessage(object sender, int timerEventId)
            : base(sender)
        {
            TimerEventId = timerEventId;
        }

        public override string ToString()
        {
            return string.Format("Timer Event Id: {0}", TimerEventId);
        }
    }
}
