using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Upload_Button_Click(object sender, EventArgs e)
    {
        String fileName = txt_fileName.Text;
        FileUpload filePath = FileUploadPath;
        UploadService uploadServiceObj = new UploadService();
        String returnVal  = uploadServiceObj.UploadFileService(fileName, filePath);
    }
}
