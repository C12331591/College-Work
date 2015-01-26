import java.sql.*;
import java.io.*;
/*import java.lang.*;
import java.sql.CallableStatement;
import java.sql.Types;
*/
import oracle.jdbc.driver.*; //make sure this is in classpath
public class CallGet {
  public static void main (String args [])
	throws SQLException, IOException {
    try {
	  Class.forName("oracle.jdbc.driver.OracleDriver");
      System.out.println("driver loaded");
    } catch (ClassNotFoundException e) {
	    System.out.println ("Could not load the driver");
	}
    String servername = "redwood.ict.ad.dit.ie";
    String portnumber = "1521";
    String servicename = "pdb12c.ict.ad.dit.ie";
    String url = "jdbc:oracle:thin:@//" + servername + ":" + portnumber + "/" + servicename;// sid;
    String user, pass;
	user = readEntry("userid  : ");
	pass = readEntry("password: ");
//    System.out.println(url);
    DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());
	//System.out.println ("before connection");

    Connection conn = DriverManager.getConnection(url, user, pass);
	//System.out.println ("after connection");
    int cnum = readNumber("Enter the customer number to get details:");
    CallableStatement stmt = conn.prepareCall ("{call builder2.CUSTORDERS.get_cust(?,?,?)}");
    stmt.setInt(1,cnum);
    stmt.registerOutParameter(2,Types.VARCHAR);
    stmt.registerOutParameter(3,Types.VARCHAR);
    stmt.execute();
    System.out.println("Name                 Address");
    System.out.println(stmt.getString(2)+" lives in "+stmt.getString(3));
 /*   String custname = stmt.getString(2);
    String custaddr = stmt.getString(3);
	System.out.println(rset.getString(1) + " " +
	                   rset.getString(2));
 */   
    stmt.close();
    conn.close();
  }
//readEntry function -- to read input string
static String readEntry(String prompt) {
	   try {
		 StringBuffer buffer = new StringBuffer();
		 System.out.print(prompt);
		 System.out.flush();
		 int c = System.in.read();
		 while (c != '\n' && c != -1) {
		   buffer.append((char)c);
		   c = System.in.read();
	     }
	     return buffer.toString().trim();
      }  catch (IOException e) {
		 return "";
	     }
  }

//readNumber function -- to read input number
static int readNumber(String prompt)
	   throws IOException{
	   String snum;
	   int num = 0;
	   boolean numok;
	   do {
		 snum = readEntry(prompt);
		 try {
		   num = Integer.parseInt(snum);
		   numok = true;
	   } catch (NumberFormatException e) {
		   numok = false;
		   System.out.println("Invalid number; enter again");
	   }
} while (!numok);
return num;
}
}
