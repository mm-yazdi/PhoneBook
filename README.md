# 📒 PhoneBook

یک پروژه‌ی ساده‌ی دفترچه تلفن نوشته شده با **C#** و **.NET 9**.  
این پروژه برای تمرین مفاهیم اصلی **Entity Framework Core**, **Repository Pattern** و معماری لایه‌ای ساخته شده است.  

---

## 🚀 ویژگی‌ها
- افزودن مخاطب جدید (Name, PhoneNumber, Email)
- ویرایش اطلاعات مخاطب
- مشاهده لیست همه مخاطبین
- حذف مخاطب بر اساس Id
- ذخیره‌سازی داده‌ها در **SQL Server** با استفاده از **EF Core**

---

## 🏗️ معماری پروژه
- **Domain** → شامل مدل‌ها و اینترفیس‌ها  
- **Application** → شامل سرویس‌ها و منطق برنامه  
- **Infrastructure** → دسترسی به دیتابیس و Repository ها  
- **Presentation (Console App)** → لایه رابط کاربری (تعامل با کاربر)

---

## ⚙️ نحوه اجرا
1. کلون کردن پروژه:
   ```bash
   git clone https://github.com/mm-yazdi/PhoneBook.git
