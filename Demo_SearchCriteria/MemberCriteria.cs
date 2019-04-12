using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSF.Common.SearchCriteria;

namespace Demo_SearchCriteria
{
    public class MemberCriteria : BaseCriteria<Member>
    {
        private string _ID;
        public string ID
        {
            //get { return _ID; }
            set
            {
                var criteriaItem = value.Split(',');

                if (criteriaItem.Length == 2)
                {
                    if (Int32.Parse(criteriaItem[0].Trim()) > Int32.Parse(criteriaItem[1].Trim()))
                    {
                        throw new ArgumentException($"{criteriaItem[1].Trim()} 不該大於 {criteriaItem[0].Trim()}");
                    }

                    TryAddCriteria(nameof(this.ID), (object)value, item => item.ID >= Int32.Parse(criteriaItem[0].Trim()) && item.ID <= Int32.Parse(criteriaItem[1].Trim()));
                }
                else
                {
                    TryAddCriteria(nameof(this.ID), (object)value, item => item.ID.Equals(Int32.Parse(criteriaItem[0].Trim())));
                }

                _ID = value;
            }
        }

        private string _Name { get; set; }
        public string Name
        {
            get { return _Name; }
            set
            {
                TryAddCriteria(nameof(this.Name), (object)value, item => item.Name.Contains(value));
                _Name = value;
            }
        }

        private string _Title { get; set; }
        public string Title
        {
            get { return _Title; }
            set
            {
                TryAddCriteria(nameof(this.Title), (object)value, item => item.Title.Equals(value));
                _Title = value;
            }
        }

        private string _Department { get; set; }
        public string Department
        {
            get { return _Department; }
            set
            {
                TryAddCriteria(nameof(this.Department), (object)value, item => item.Department.Equals(value));
                _Department = value;
            }
        }
    }
}
