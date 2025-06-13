// SynchronizationContext Sample
namespace CallToMainThread
{
    public delegate void AddItemDelegate(object state);
    public partial class Form1 : Form
    {
      AddItemDelegate _addItemDelegate;
      SynchronizationContext _context;
      
      public Form1()
      {
         InitializeComponent();
         // Gets the synchronization context for the current thread
         _context = SynchronizationContext.Current;
         _addItemDelegate = new AddItemDelegate(AddItemMethod);
      }
      
      private void Form1_Load(object sender, EventArgs e)
      {
         Thread t = new Thread(new ThreadStart(SecondaryThread));
          t.Start();
      }
      
      private void SecondaryThread()
      {
         // 
          _context.Post(new SendOrPostCallback(AddItemMethod), null);
      }
      
      private void AddItemMethod(object state)
      {
          for (int index = 0; index < 100; index++)
            treeView1.Nodes.Add("Test " + index.ToString());
      }
   }
}

 
 
 
