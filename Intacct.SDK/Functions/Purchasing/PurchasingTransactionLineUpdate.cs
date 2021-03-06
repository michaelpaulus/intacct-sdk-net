﻿/*
 * Copyright 2018 Sage Intacct, Inc.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using System;
using Intacct.SDK.Functions.InventoryControl;
using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.Purchasing
{
    public class PurchasingTransactionLineUpdate : AbstractPurchasingTransactionLine
    {

        private int _lineNo;
        
        public int LineNo
        {
            get => _lineNo;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Line No must be greater than zero");
                }

                _lineNo = value;
            }
        }

        public PurchasingTransactionLineUpdate()
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("updatepotransitem");
            xml.WriteAttribute("line_num", LineNo);

            xml.WriteElement("itemid", ItemId);
            xml.WriteElement("itemdesc", ItemDescription);
            xml.WriteElement("taxable", Taxable);
            xml.WriteElement("warehouseid", WarehouseId);
            xml.WriteElement("quantity", Quantity);
            xml.WriteElement("unit", Unit);
            xml.WriteElement("price", Price);
            xml.WriteElement("overridetaxamount", OverrideTaxAmount);
            xml.WriteElement("tax", Tax);
            xml.WriteElement("locationid", LocationId);
            xml.WriteElement("departmentid", DepartmentId);
            xml.WriteElement("memo", Memo);

            if (ItemDetails.Count > 0)
            {
                xml.WriteStartElement("updateitemdetails");
                foreach (AbstractTransactionItemDetail itemDetail in ItemDetails)
                {
                    itemDetail.WriteXml(ref xml);
                }
                xml.WriteEndElement(); //updateitemdetails
            }

            xml.WriteElement("form1099", Form1099);

            xml.WriteCustomFieldsExplicit(CustomFields);

            xml.WriteElement("projectid", ProjectId);
            xml.WriteElement("customerid", CustomerId);
            xml.WriteElement("vendorid", VendorId);
            xml.WriteElement("employeeid", EmployeeId);
            xml.WriteElement("classid", ClassId);
            xml.WriteElement("contractid", ContractId);
            xml.WriteElement("billable", Billable);

            xml.WriteEndElement(); //updatepotransitem 
        }

    }
}