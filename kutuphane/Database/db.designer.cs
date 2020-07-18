﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kutuphane.Database
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="kutuphanedb")]
	public partial class dbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public dbDataContext() : 
				base(global::kutuphane.Properties.Settings.Default.kutuphanedbConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public dbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<view_iade> view_iades
		{
			get
			{
				return this.GetTable<view_iade>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.view_iade")]
	public partial class view_iade
	{
		
		private int _odunc_no;
		
		private System.Nullable<int> _uye_no;
		
		private long _uye_tcno;
		
		private string _adisoyadi;
		
		private string _uye_tel;
		
		private int _kitap_no;
		
		private System.Nullable<long> _kitap_barkod;
		
		private string _kitap_adi;
		
		private System.Nullable<System.DateTime> _odunc_alim_tarihi;
		
		private System.Nullable<System.DateTime> _odunc_teslim_tarihi;
		
		private System.Nullable<System.DateTime> _odunc_teslimetmesi_gereken_tarih;
		
		private System.Nullable<bool> _iadeEdildiMi;
		
		public view_iade()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_odunc_no", DbType="Int NOT NULL")]
		public int odunc_no
		{
			get
			{
				return this._odunc_no;
			}
			set
			{
				if ((this._odunc_no != value))
				{
					this._odunc_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uye_no", DbType="Int")]
		public System.Nullable<int> uye_no
		{
			get
			{
				return this._uye_no;
			}
			set
			{
				if ((this._uye_no != value))
				{
					this._uye_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uye_tcno", DbType="BigInt NOT NULL")]
		public long uye_tcno
		{
			get
			{
				return this._uye_tcno;
			}
			set
			{
				if ((this._uye_tcno != value))
				{
					this._uye_tcno = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_adisoyadi", DbType="VarChar(101)")]
		public string adisoyadi
		{
			get
			{
				return this._adisoyadi;
			}
			set
			{
				if ((this._adisoyadi != value))
				{
					this._adisoyadi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uye_tel", DbType="NVarChar(50)")]
		public string uye_tel
		{
			get
			{
				return this._uye_tel;
			}
			set
			{
				if ((this._uye_tel != value))
				{
					this._uye_tel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kitap_no", DbType="Int NOT NULL")]
		public int kitap_no
		{
			get
			{
				return this._kitap_no;
			}
			set
			{
				if ((this._kitap_no != value))
				{
					this._kitap_no = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kitap_barkod", DbType="BigInt")]
		public System.Nullable<long> kitap_barkod
		{
			get
			{
				return this._kitap_barkod;
			}
			set
			{
				if ((this._kitap_barkod != value))
				{
					this._kitap_barkod = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kitap_adi", DbType="NVarChar(50)")]
		public string kitap_adi
		{
			get
			{
				return this._kitap_adi;
			}
			set
			{
				if ((this._kitap_adi != value))
				{
					this._kitap_adi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_odunc_alim_tarihi", DbType="Date")]
		public System.Nullable<System.DateTime> odunc_alim_tarihi
		{
			get
			{
				return this._odunc_alim_tarihi;
			}
			set
			{
				if ((this._odunc_alim_tarihi != value))
				{
					this._odunc_alim_tarihi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_odunc_teslim_tarihi", DbType="Date")]
		public System.Nullable<System.DateTime> odunc_teslim_tarihi
		{
			get
			{
				return this._odunc_teslim_tarihi;
			}
			set
			{
				if ((this._odunc_teslim_tarihi != value))
				{
					this._odunc_teslim_tarihi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_odunc_teslimetmesi_gereken_tarih", DbType="DateTime")]
		public System.Nullable<System.DateTime> odunc_teslimetmesi_gereken_tarih
		{
			get
			{
				return this._odunc_teslimetmesi_gereken_tarih;
			}
			set
			{
				if ((this._odunc_teslimetmesi_gereken_tarih != value))
				{
					this._odunc_teslimetmesi_gereken_tarih = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_iadeEdildiMi", DbType="Bit")]
		public System.Nullable<bool> iadeEdildiMi
		{
			get
			{
				return this._iadeEdildiMi;
			}
			set
			{
				if ((this._iadeEdildiMi != value))
				{
					this._iadeEdildiMi = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
