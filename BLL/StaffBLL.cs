using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appprop;
using DAL;
using System.Data;

namespace BLL
{
    public class StaffBLL
    {
        public int InsertStaff(StaffSchema stf) {
            try {

                Staff objstaff = new Staff();
                return objstaff.InsertData(stf);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataTable Staff_Details() {

            try
            {
                Staff objStaff=new Staff();
                return objStaff.GetDetails();

            }
            catch (Exception ex) 
            {

                throw ex;
            }
        
        
        }
        public int InsertAddress(StaffSchema stf)
        {
            try
            {

                Staff objstaffaddress = new Staff();
                return objstaffaddress.InsertAddress(stf);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public int InserOtherDtails(StaffSchema stf) {

            try
            {

                Staff objstaff = new Staff();
                return objstaff.InsertOtherDetails(stf);

            }
            catch (Exception ex) {
                throw ex;
            }
        
        
        }
        public int ProofInsert(StaffSchema sfs) {
            try 
            {
                Staff obj = new Staff();
                return obj.InsertProof(sfs);
            
            }
            catch (Exception ex) 
            {
                throw ex;
            
            }
        
        
        }

        public int PositionInsert(StaffSchema sfs) {

            try 
            {
               Staff objp = new Staff();
               return objp.Postion_Insert(sfs);

            }
            catch(Exception ex) 
            {
                throw ex;
            }
        
        }
        public DataTable Staff_Verfication(StaffSchema sfs)
        {

            try
            {
                Staff objStaff = new Staff();
                return objStaff.GetVerfDetails(sfs);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
