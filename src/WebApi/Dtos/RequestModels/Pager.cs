﻿using WepApi.Entities;
using System.ComponentModel;

namespace WepApi.DTOs.RequestModels
{
    public class Pager
    {
        /// <summary>
        /// Số lượng bản ghi cần lấy ra
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Số trang hiện tại
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// Sắp xếp theo trường nào
        /// </summary>
        [DefaultValue("ID")]
        public string? SortBy { get; set; } = "ID";
        /// <summary>
        /// Sắp xếp theo DESC hay ASC
        /// </summary>
        [DefaultValue("desc")]
        public string? OrderBy { get; set; } = "desc";
        [DefaultValue("")]
        public string? Keyword { get; set; } = "";
    }
}
