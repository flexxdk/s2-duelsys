using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BLL.Objects;

namespace WinApp.Forms
{
    public partial class MatchForm : Form
    {
        public Match CurrentMatch { get; private set; }

        public MatchForm(Match match)
        {
            InitializeComponent();
            CurrentMatch = match;
            SetupForm();
        }

        private void SetupForm()
        {
            lblHomeName.Text = CurrentMatch.HomeName;
            numHomeScore.Value = CurrentMatch.HomeScore;
            lblAwayName.Text = CurrentMatch.AwayName;
            numAwayScore.Value = CurrentMatch.AwayScore;
        }

        private void btnSaveMatchResults_Click(object sender, EventArgs e)
        {
            CurrentMatch.HomeScore = Convert.ToInt32(numHomeScore.Value);
            CurrentMatch.AwayScore = Convert.ToInt32(numAwayScore.Value);
            CurrentMatch.IsFinished = true;
        }
    }
}
