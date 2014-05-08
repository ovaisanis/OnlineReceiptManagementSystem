//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ReceiptManagement.Common.Entities
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Products_Services : Entities.EntityObject
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.Products_Services products_Services);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public Products_Services() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a Products_Services.
    	/// </summary>
    	/// <returns>The new Products_Services instance. </returns>
    	public static Entities.Products_Services Factory()
    	{
    		OnCreating();
    		Entities.Products_Services products_Services = new Entities.Products_Services();
    		OnCreated(products_Services);
    		
    		return products_Services;
    	}

        #endregion

    
        #region Primitive Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual long Id
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<int> CategoryId
        {
            get { return _categoryId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_categoryId != value)
                    {
                        if (Product_Service_Categories != null && Product_Service_Categories.Id != value)
                        {
                            Product_Service_Categories = null;
                        }
                        _categoryId = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<int> _categoryId;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<int> SubCategoryId
        {
            get { return _subCategoryId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_subCategoryId != value)
                    {
                        if (Product_Service_SubCategories != null && Product_Service_SubCategories.Id != value)
                        {
                            Product_Service_SubCategories = null;
                        }
                        _subCategoryId = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<int> _subCategoryId;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<long> UserId
        {
            get { return _userId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_userId != value)
                    {
                        if (User != null && User.Id != value)
                        {
                            User = null;
                        }
                        _userId = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<long> _userId;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<bool> IsDeleted
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<My_Products_Services> My_Products_Services
        {
            get
            {
                if (_my_Products_Services == null)
                {
                    var newCollection = new FixupCollection<My_Products_Services>();
                    newCollection.CollectionChanged += FixupMy_Products_Services;
                    _my_Products_Services = newCollection;
                }
                return _my_Products_Services;
            }
            set
            {
                if (!ReferenceEquals(_my_Products_Services, value))
                {
                    var previousValue = _my_Products_Services as FixupCollection<My_Products_Services>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMy_Products_Services;
                    }
                    _my_Products_Services = value;
                    var newValue = value as FixupCollection<My_Products_Services>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMy_Products_Services;
                    }
                }
            }
        }
        private ICollection<My_Products_Services> _my_Products_Services;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual Product_Service_Categories Product_Service_Categories
        {
            get { return _product_Service_Categories; }
            set
            {
                if (!ReferenceEquals(_product_Service_Categories, value))
                {
                    var previousValue = _product_Service_Categories;
                    _product_Service_Categories = value;
                    FixupProduct_Service_Categories(previousValue);
                }
            }
        }
        private Product_Service_Categories _product_Service_Categories;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<Product_Service_Images> Product_Service_Images
        {
            get
            {
                if (_product_Service_Images == null)
                {
                    var newCollection = new FixupCollection<Product_Service_Images>();
                    newCollection.CollectionChanged += FixupProduct_Service_Images;
                    _product_Service_Images = newCollection;
                }
                return _product_Service_Images;
            }
            set
            {
                if (!ReferenceEquals(_product_Service_Images, value))
                {
                    var previousValue = _product_Service_Images as FixupCollection<Product_Service_Images>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProduct_Service_Images;
                    }
                    _product_Service_Images = value;
                    var newValue = value as FixupCollection<Product_Service_Images>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProduct_Service_Images;
                    }
                }
            }
        }
        private ICollection<Product_Service_Images> _product_Service_Images;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual Product_Service_SubCategories Product_Service_SubCategories
        {
            get { return _product_Service_SubCategories; }
            set
            {
                if (!ReferenceEquals(_product_Service_SubCategories, value))
                {
                    var previousValue = _product_Service_SubCategories;
                    _product_Service_SubCategories = value;
                    FixupProduct_Service_SubCategories(previousValue);
                }
            }
        }
        private Product_Service_SubCategories _product_Service_SubCategories;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private User _user;

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupProduct_Service_Categories(Product_Service_Categories previousValue)
        {
            if (previousValue != null && previousValue.Products_Services.Contains(this))
            {
                previousValue.Products_Services.Remove(this);
            }
    
            if (Product_Service_Categories != null)
            {
                if (!Product_Service_Categories.Products_Services.Contains(this))
                {
                    Product_Service_Categories.Products_Services.Add(this);
                }
                if (CategoryId != Product_Service_Categories.Id)
                {
                    CategoryId = Product_Service_Categories.Id;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //CategoryId = null;
            }
        }
    
        private void FixupProduct_Service_SubCategories(Product_Service_SubCategories previousValue)
        {
            if (previousValue != null && previousValue.Products_Services.Contains(this))
            {
                previousValue.Products_Services.Remove(this);
            }
    
            if (Product_Service_SubCategories != null)
            {
                if (!Product_Service_SubCategories.Products_Services.Contains(this))
                {
                    Product_Service_SubCategories.Products_Services.Add(this);
                }
                if (SubCategoryId != Product_Service_SubCategories.Id)
                {
                    SubCategoryId = Product_Service_SubCategories.Id;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //SubCategoryId = null;
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.Products_Services.Contains(this))
            {
                previousValue.Products_Services.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Products_Services.Contains(this))
                {
                    User.Products_Services.Add(this);
                }
                if (UserId != User.Id)
                {
                    UserId = User.Id;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //UserId = null;
            }
        }
    
        private void FixupMy_Products_Services(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (My_Products_Services item in e.NewItems)
                {
                    item.Products_Services = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (My_Products_Services item in e.OldItems)
                {
                    if (ReferenceEquals(item.Products_Services, this))
                    {
                        item.Products_Services = null;
                    }
                }
            }
        }
    
        private void FixupProduct_Service_Images(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Product_Service_Images item in e.NewItems)
                {
                    item.Products_Services = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product_Service_Images item in e.OldItems)
                {
                    if (ReferenceEquals(item.Products_Services, this))
                    {
                        item.Products_Services = null;
                    }
                }
            }
        }

        #endregion

    }
}