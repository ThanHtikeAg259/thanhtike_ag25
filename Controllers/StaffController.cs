//<copyright file ="StaffController.cs"  company ="Seattle Consulting Myanmar">
//Copyright(c) 2021  All Rights Reserved
//</copyright>
//<author> NAWZIN-PC\Naw Zin Marlar Win </author>
//<date>10/4/2021</date>

namespace POS_OJT.Controllers
{
    using POS_OJT.Config;
    using POS_OJT.Models;
    using POS_OJT.Services;
    using POS_OJT.Utilities;
    using POS_OJT.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Web;
    using System.Web.Mvc;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Defines the <see cref="StaffController" />.
    /// </summary>
    public class StaffController : Controller
    {
        /// <summary>
        /// Defines the staffService.
        /// </summary>
        private StaffService staffService = new StaffService();

        /// <summary>
        /// Defines the dtStaffList, dtShop.
        /// </summary>
        private DataTable dtStaffList = new DataTable(),
                          dtShop = new DataTable();

        /// <summary>
        /// Defines the connection.
        /// </summary>
        private DbConnection connection = new DbConnection();

        /// <summary>
        /// Defines the staff.
        /// </summary>
        private Staff staff;

        // GET: Staff
        /// <summary>
        /// The Index.
        /// </summary>
        /// <param name="staffName">The staffName<see cref="string"/>.</param>
        /// <param name="ddlStaffNo">The ddlStaffNo<see cref="string"/>.</param>
        /// <param name="joinFrom">The joinFrom<see cref="string"/>.</param>
        /// <param name="ddlStaffRole">The ddlStaffRole<see cref="string"/>.</param>
        /// <param name="ddlStaffType">The ddlStaffType<see cref="string"/>.</param>
        /// <param name="ddlStaffPosition">The ddlStaffPosition<see cref="string"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index(string staffName, string ddlStaffNo, string joinFrom, string ddlStaffRole, string ddlStaffType, string ddlStaffPosition)
        {
            dtStaffList = staffService.GetStaff();
            List<Staff> staffNo = new List<Staff>();

            staffNo = (from DataRow dr in dtStaffList.Rows
                       select new Staff()
                       {
                           name = Convert.ToString(dr["name"]),
                           staff_number = Convert.ToString(dr["staff_number"]),
                       }).ToList();

            SelectList list = new SelectList(staffNo, "name", "staff_number");
            ViewBag.staffnumber = list;

            //Staff Type List(For DropDown Filtering)
            List<SelectListItem> staffType = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Full Time", Value = "1"
                },
                new SelectListItem
                {
                    Text = "Part Time", Value = "2"
                }
            };
            ViewBag.staffType = staffType;

            //User Role List(For DropDown Filtering)
            List<SelectListItem> staffRole = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Super Admin", Value = "1"
                },
                new SelectListItem
                {
                    Text = "Company Admin", Value = "2"
                },
                new SelectListItem
                {
                    Text = "Shop Admin", Value = "3"
                },
                new SelectListItem
                {
                    Text = "Waiter Staff", Value = "4"
                },
                new SelectListItem
                {
                    Text = "Kitchen Staff", Value = "5"
                },
                new SelectListItem
                {
                    Text = "Cashier Staff", Value = "6"
                },
                new SelectListItem
                {
                    Text = "Sale Staff", Value = "7"
                }
            };

            ViewBag.staffRole = staffRole;

            //User Position List(For DropDown Filtering)
            List<SelectListItem> staffPosition = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Cashier", Value = "Cashier"
                },
                new SelectListItem
                {
                    Text = "Manager", Value = "Manager"
                },
                new SelectListItem
                {
                    Text = "Sales Associate", Value = "Sales Associate"
                }
            };

            ViewBag.staffPosition = staffPosition;

            List<StaffViewModel> staffListModel = new List<StaffViewModel>();
            staffListModel = DataTableToList.ConvertToList<StaffViewModel>(dtStaffList);

            return View(staffListModel.Where(
                x => x.name == staffName && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || staffName == null
                || staffName == string.Empty && x.name == ddlStaffNo && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || staffName == string.Empty && ddlStaffNo == string.Empty && Convert.ToString(x.role) == ddlStaffRole && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || staffName == string.Empty && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && Convert.ToString(x.staff_type) == ddlStaffType && ddlStaffPosition == string.Empty
                || staffName == string.Empty && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && x.position == ddlStaffPosition
                || x.name == staffName && x.name == ddlStaffNo && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || x.name == staffName && ddlStaffNo == string.Empty && Convert.ToString(x.role) == ddlStaffRole && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || x.name == staffName && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && Convert.ToString(x.staff_type) == ddlStaffType && ddlStaffPosition == string.Empty
                || x.name == staffName && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && x.position == ddlStaffPosition
                || staffName == string.Empty && x.name == ddlStaffNo && Convert.ToString(x.role) == ddlStaffRole && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                || staffName == string.Empty && x.name == ddlStaffNo && ddlStaffRole == string.Empty && Convert.ToString(x.staff_type) == ddlStaffType && ddlStaffPosition == string.Empty
                || staffName == string.Empty && x.name == ddlStaffNo && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && x.position == ddlStaffPosition
                || staffName == string.Empty && ddlStaffNo == string.Empty && Convert.ToString(x.role) == ddlStaffRole && Convert.ToString(x.staff_type) == ddlStaffType && ddlStaffPosition == string.Empty
                || staffName == string.Empty && ddlStaffNo == string.Empty && Convert.ToString(x.role) == ddlStaffRole && ddlStaffType == string.Empty && x.position == ddlStaffPosition
                || staffName == string.Empty && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && Convert.ToString(x.staff_type) == ddlStaffType && x.position == ddlStaffPosition
                || Convert.ToString(x.join_from) == joinFrom
                || staffName == string.Empty && ddlStaffNo == string.Empty && ddlStaffRole == string.Empty && ddlStaffType == string.Empty && ddlStaffPosition == string.Empty
                ));
        }

        //Excel Download
        /// <summary>
        /// The Download.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Download()
        {
            dtStaffList = staffService.GetStaff();

            List<StaffViewModel> staffListModel = new List<StaffViewModel>();
            staffListModel = DataTableToList.ConvertToList<StaffViewModel>(dtStaffList);
            ViewBag.staffListDL = staffListModel;

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Cells[1, 1] = "Name";
            worksheet.Cells[1, 2] = "User No";
            worksheet.Cells[1, 3] = "Role";
            worksheet.Cells[1, 4] = "User Type";
            worksheet.Cells[1, 5] = "Position";
            worksheet.Cells[1, 6] = "Current Job Place";
            worksheet.Cells[1, 7] = "NRC No";
            worksheet.Cells[1, 8] = "Join From";

            int row = 2;
            foreach (var item in staffListModel)
            {
                worksheet.Cells[row, 1] = item.name;
                worksheet.Cells[row, 2] = item.staff_number;
                worksheet.Cells[row, 3] = item.role;
                worksheet.Cells[row, 4] = item.staff_type;
                worksheet.Cells[row, 5] = item.position;
                worksheet.Cells[row, 6] = item.name1;
                worksheet.Cells[row, 7] = item.nrc_number;
                worksheet.Cells[row, 8] = item.join_from;
                row++;
            }
            workbook.SaveAs("d:\\staff_list.xls");
            workbook.Close();
            Marshal.ReleaseComObject(workbook);

            application.Quit();
            Marshal.FinalReleaseComObject(application);
            ViewBag.Result = "Success";
            return RedirectToAction("Index");
        }

        //*************************************************************************************
        // GET: Staff/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="staff">The staff<see cref="Staff"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Create(Staff staff)
        {
            DataTable dtShop = new DataTable();
            List<Shop> shopList = new List<Shop>();
            //Staff Role DropDown List
            List<SelectListItem> staffRole = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Super Admin", Value = "1"
                },
                new SelectListItem
                {
                    Text = "Company Admin", Value = "2"
                },
                new SelectListItem
                {
                    Text = "Shop Admin", Value = "3"
                },
                new SelectListItem
                {
                    Text = "Waiter Staff", Value = "4"
                },
                new SelectListItem
                {
                    Text = "Kitchen Staff", Value = "5"
                },
                new SelectListItem
                {
                    Text = "Cashier Staff", Value = "6"
                },
                new SelectListItem
                {
                    Text = "Sale Staff", Value = "7"
                }
            };
            ViewBag.staffRole = staffRole;

            //Staff Position DropDown List
            List<SelectListItem> staffPosition = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Cashier", Value = "Cashier"
                },
                new SelectListItem
                {
                    Text = "Manager", Value = "Manager"
                },
                new SelectListItem
                {
                    Text = "Sales Assocaite", Value = "Sales Associate"
                }
            };
            ViewBag.staffPosition = staffPosition;

            List<SelectListItem> staffType = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Full Time", Value = "1"
                },
                new SelectListItem
                {
                    Text = "Part Time", Value = "2"
                }
            };
            ViewBag.staffType = staffType;

            dtShop = staffService.GetShop();
            shopList = (from DataRow dr in dtShop.Rows
                        select new Shop()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString()
                        }).ToList();

            SelectList shopName = new SelectList(shopList, "id", "name");
            ViewBag.shopname = shopName;

            staff.dob = null;
            staff.join_from = null;
            staff.join_to = null;

            return View(staff);
        }

        // POST: Staff/Create
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <param name="photo">The photo<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase photo)
        {
            staff = new Staff();
            int ddlStatusValue = Convert.ToInt32(Request.Form["ddlCheckBox"]);
            staff.name = collection[2];
            staff.password = collection[4];
            staff.position = collection[6];
            staff.nrc_number = collection[8];
            staff.gender = Convert.ToInt16(collection[10]);
            staff.phone_number_1 = collection[12];
            staff.phone_number_2 = collection[13];
            staff.dob = Convert.ToDateTime(collection[14]);
            staff.race = collection[16];
            staff.address = collection[18];
            staff.join_from = Convert.ToDateTime(collection[19]);
            if (collection[20] == string.Empty)
            {
                staff.join_to = null;
            }
            else
            {
                staff.join_to = Convert.ToDateTime(collection[20]);
            }
            staff.staff_number = collection[1];
            staff.role = Convert.ToInt32(collection[3]);
            staff.staff_type = Convert.ToInt32(collection[7]);
            staff.bank_account_number = collection[9];
            staff.marital_status = Convert.ToInt16(collection[11]);
            staff.graduated_univeristy = collection[15];
            staff.city = collection[17];

            if (photo != null)
            {
                string ImageName = System.IO.Path.GetFileName(photo.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/images/upload/staff/"), ImageName);

                photo.SaveAs(physicalPath);
                staff.photo = ImageName;
            }

            if (ddlStatusValue == null || ddlStatusValue == 0)
            {
                staff.staff_status = 2;
            }
            else
            {
                staff.staff_status = 1;
            }
            staff.create_user_id = 1;
            staff.create_datetime = DateTime.Now.Date;
            staff.update_user_id = 1;
            staff.update_datetime = DateTime.Now.Date;
            staff.company_id = 1;
            staff.shop_id = Convert.ToInt32(collection[21]);
            staff.warehouse_id = 1;

            staffService.Insert(staff);
            return RedirectToAction("Index", "Staff", new { ID = 0, name = string.Empty });
        }

        /// <summary>
        /// The LoadStaffNo.
        /// </summary>
        /// <param name="role">The role<see cref="int"/>.</param>
        /// <returns>The <see cref="JsonResult"/>.</returns>
        public JsonResult LoadStaffNo(int role)
        {
            string staffRole = string.Empty;
            if (role == 1)
            {
                staffRole = staffService.GetSuperAdmin(role);
            }
            else if (role == 2)
            {
                staffRole = staffService.GetCompanyAdmin(role);
            }
            else if (role == 3)
            {
                staffRole = staffService.GetShopAdmin(role);
            }
            else if (role == 4)
            {
                staffRole = staffService.GetWaiterStaff(role);
            }
            else if (role == 5)
            {
                staffRole = staffService.GetKitchenStaff(role);
            }
            else if (role == 6)
            {
                staffRole = staffService.GetCashierStaff(role);
            }
            else if (role == 7)
            {
                staffRole = staffService.GetSaleStaff(role);
            }

            return new JsonResult { Data = staffRole };
        }

        // GET: Staff/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Edit(int id)
        {
            int staffRoleNo = Convert.ToInt32(staffService.DisplayStaff(id));
            //Staff Role DropDown List
            List<SelectListItem> staffRole = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Super Admin", Value = "1", Selected= true ? staffRoleNo == 1 : false
                },
                new SelectListItem
                {
                    Text = "Company Admin", Value = "2", Selected= true ? staffRoleNo == 2 : false
                },
                new SelectListItem
                {
                    Text = "Shop Admin", Value = "3", Selected= true ? staffRoleNo == 3 : false
                },
                new SelectListItem
                {
                    Text = "Waiter Staff", Value = "4", Selected= true ? staffRoleNo == 4 : false
                },
                new SelectListItem
                {
                    Text = "Kitchen Staff", Value = "5", Selected= true ? staffRoleNo == 5 : false
                },
                new SelectListItem
                {
                    Text = "Cashier Staff", Value = "6", Selected= true ? staffRoleNo == 6 : false
                },
                new SelectListItem
                {
                    Text = "Sale Staff", Value = "7", Selected= true ? staffRoleNo == 7 : false
                }
            };

            ViewBag.staffRole = staffRole;

            string positionName = staffService.ShowPosition(id).ToString();
            //Staff Position DropDown List
            List<SelectListItem> staffPosition = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Cashier", Value = "Cashier", Selected= true ? positionName == "Cashier" : false
                },
                new SelectListItem
                {
                    Text = "Manager", Value = "Manager", Selected= true ? positionName == "Manager" : false
                },
                new SelectListItem
                {
                    Text = "Sales Assocaite", Value = "Sales Associate", Selected= true ? positionName == "Sales Associate" : false
                }
            };
            ViewBag.staffPosition = staffPosition;

            int type = Convert.ToInt32(staffService.DisplayTypeList(id));
            List<SelectListItem> staffType = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "Full Time", Value = "1", Selected= true ? type == 1 : false
                },
                new SelectListItem
                {
                    Text = "Part Time", Value = "2", Selected= true ? type == 2 : false
                }
            };

            ViewBag.staffType = staffType;

            dtShop = staffService.GetShop();
            List<Shop> shopList = new List<Shop>();

            shopList = (from DataRow dr in dtShop.Rows
                        select new Shop()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString()
                        }).ToList();

            SelectList shopName = new SelectList(shopList, "id", "name");
            ViewBag.shopname = shopName;

            dtStaffList = staffService.GetEdit();
            List<Staff> staffListModel = new List<Staff>();
            staffListModel = DataTableToList.ConvertToList<Staff>(dtStaffList);

            return View(staffListModel.Find(item => item.id == id));
        }

        // POST: Staff/Edit/5
        /// <summary>
        /// The Edit.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="collection">The collection<see cref="FormCollection"/>.</param>
        /// <param name="photo">The photo<see cref="HttpPostedFileBase"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase photo)
        {
            staff = new Staff();
            staff.id = id;
            staff.name = collection[1];
            staff.password = collection[3];
            staff.position = collection[5];
            staff.nrc_number = collection[7];
            staff.gender = Convert.ToInt16(collection[9]);
            staff.phone_number_1 = collection[11];
            staff.phone_number_2 = collection[12];
            if (collection[13].ToString() == string.Empty)
            {
                staff.dob = null;
            }
            else
            {
                staff.dob = Convert.ToDateTime(collection[13]);
            }
            staff.race = collection[15];
            staff.address = collection[17];
            if (collection[18].ToString() == string.Empty)
            {
                staff.join_from = null;
            }
            else
            {
                staff.join_from = Convert.ToDateTime(collection[18]);
            }
            if (collection[19].ToString() == string.Empty)
            {
                staff.join_to = null;
            }
            else
            {
                staff.join_to = Convert.ToDateTime(collection[19]);
            }
            staff.role = Convert.ToInt32(collection[2]);

            staff.staff_type = Convert.ToInt32(collection[6]);
            staff.bank_account_number = collection[8];
            staff.marital_status = Convert.ToInt16(collection[10]);
            staff.graduated_univeristy = collection[14];
            staff.city = collection[16];

            if (photo != null)
            {
                string ImageName = System.IO.Path.GetFileName(photo.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/images/upload/staff/"), ImageName);

                photo.SaveAs(physicalPath);
                staff.photo = ImageName;
            }
            staff.staff_status = 1;
            staff.create_user_id = 1;
            staff.update_user_id = 1;
            staff.update_datetime = DateTime.Now.Date;
            staff.company_id = 1;
            staff.shop_id = Convert.ToInt32(collection[20]);
            staff.warehouse_id = 1;

            staffService.Edit(staff);

            return RedirectToAction("Index", "Staff", new { ID = 0, name = string.Empty });
        }

        // POST: Staff/Delete/5
        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Delete(int id)
        {
            staff = new Staff();
            staff.id = id;
            staff.staff_status = 3;

            staffService.Delete(staff);
            return RedirectToAction("Index");
        }
    }
}
