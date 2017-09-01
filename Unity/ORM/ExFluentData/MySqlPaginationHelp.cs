using FluentData;
using System;
using System.Collections.Generic;

namespace Unity.ORM.ExFluentData {
    public class MySqlPaginationHelp {
        public MySqlPaginationHelp(string countSqlStr, string pageSqlStr, IDbContext context) {
            _CountSqlStr = countSqlStr;
            _PageSqlStr = pageSqlStr;
            _context = context;
            _PageSize = 20;
        }
        //
        public IDbContext _context { get; set; }
        //
        public string _CountSqlStr { get; set; }
        public string _PageSqlStr { get; set; }
        //
        public Int32 _PageSize { get; set; }
        public Int32 _PageIndex { get; set; }
        private Int32 _pageCount = -1;
        //
        public Boolean _IsEnd { get; set; }
        public Int32 _PageCount {
            get {
                if (_pageCount < 0) {
                    _pageCount = _context.Sql(_CountSqlStr).QuerySingle<Int32>();
                }
                return _pageCount;
            }
        }
        //
        public List<T> GetPage<T>(int pageIndex) {
            var skipCount = _PageSize * _PageIndex;
            var sql = string.Format(_PageSqlStr, skipCount, _PageSize);
            var lst = _context.Sql(sql).QueryMany<T>();
            return lst;
        }
        //
        public List<T> GetNextPage<T>() {
            if (!_IsEnd) {
                var lst = GetPage<T>(_PageIndex + 1);
                _PageIndex++;
                if (_PageIndex >= _pageCount) {
                    _IsEnd = true;
                }
                return lst;
            }
            return null;
        }
    }
}
