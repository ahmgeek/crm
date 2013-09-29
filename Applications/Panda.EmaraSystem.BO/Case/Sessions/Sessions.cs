using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.EmaraSystem.BO {


  public class Sessions 
  {

      #region Private Variables
      private List<SessionQuestion> _sessionQuestions = new List<SessionQuestion>() ;

      #endregion

      public int SessionId { get; set; }
      public int CaseId { get; set; }
      public string Report { get; set; }
      public string Notes { get; set; }

      
      public List<SessionQuestion> SessionQuestions  
      {
          get { return _sessionQuestions; }
          set { _sessionQuestions = value; }
      }
      
  }
}
