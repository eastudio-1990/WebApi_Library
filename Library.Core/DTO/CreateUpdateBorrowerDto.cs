﻿namespace Library.Core.DTO
{
    public class CreateUpdateBorrowerDto
    {
        public int Id { get; set; }

        /// <summary>
        /// نام امانت گیرنده کتاب
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// امیل امانت گیرنده
        /// </summary>
        public string Email { get; set; }


        /// <summary>
        /// همراه امانت گیرنده کتاب
        /// </summary>
        public string Phone { get; set; }
    }
}
