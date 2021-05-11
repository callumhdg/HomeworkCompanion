using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HomeworkCompanion
{
    public partial class HomeworkCompanionContext : DbContext
    {
        public HomeworkCompanionContext()
        {
        }

        public HomeworkCompanionContext(DbContextOptions<HomeworkCompanionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignedQuestion> AssignedQuestions { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<HomeworkForStudent> HomeworkForStudents { get; set; }
        public virtual DbSet<QuestionTemplate> QuestionTemplates { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentsInClass> StudentsInClasses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HomeworkCompanion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AssignedQuestion>(entity =>
            {
                entity.ToTable("Assigned_Questions");

                entity.Property(e => e.AssignedQuestionId).HasColumnName("assigned_question_id");

                entity.Property(e => e.AwardedMarks).HasColumnName("awarded_marks");

                entity.Property(e => e.HomeworkIdFk).HasColumnName("homework_id_fk");

                entity.Property(e => e.MaximumMarks).HasColumnName("maximum_marks");

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("question_text");

                entity.Property(e => e.SubmitedAnswer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("submited_answer");

                entity.Property(e => e.TeachersAnswer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("teachers_answer");

                entity.HasOne(d => d.HomeworkIdFkNavigation)
                    .WithMany(p => p.AssignedQuestions)
                    .HasForeignKey(d => d.HomeworkIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assigned___homew__6C190EBB");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("class_name");

                entity.Property(e => e.ClassSubject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("class_subject");

                entity.Property(e => e.ClassTeacherFk).HasColumnName("class_teacher_fk");

                entity.HasOne(d => d.ClassTeacherFkNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ClassTeacherFk)
                    .HasConstraintName("FK__Classes__class_t__5BE2A6F2");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(e => e.HomeworkId).HasColumnName("homework_id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("due_date");

                entity.Property(e => e.Marks)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marks");

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("submission_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<HomeworkForStudent>(entity =>
            {
                entity.HasKey(e => new { e.StudentIdFk, e.HomeworkIdFk })
                    .HasName("PK__Homework__57078475918D480C");

                entity.ToTable("Homework_For_Students");

                entity.Property(e => e.StudentIdFk).HasColumnName("student_id_fk");

                entity.Property(e => e.HomeworkIdFk).HasColumnName("homework_id_fk");

                entity.HasOne(d => d.HomeworkIdFkNavigation)
                    .WithMany(p => p.HomeworkForStudents)
                    .HasForeignKey(d => d.HomeworkIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homework___homew__6754599E");

                entity.HasOne(d => d.StudentIdFkNavigation)
                    .WithMany(p => p.HomeworkForStudents)
                    .HasForeignKey(d => d.StudentIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homework___stude__66603565");
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__Question__2EC215493F782A2D");

                entity.ToTable("Question_Templates");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("answer");

                entity.Property(e => e.MaximumMarks).HasColumnName("maximum_marks");

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("question_text");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<StudentsInClass>(entity =>
            {
                entity.HasKey(e => new { e.StudentIdFk, e.ClassIdFk })
                    .HasName("PK__Students__E7850C17FA5CCA56");

                entity.ToTable("Students_In_Class");

                entity.Property(e => e.StudentIdFk).HasColumnName("student_id_fk");

                entity.Property(e => e.ClassIdFk).HasColumnName("class_id_fk");

                entity.HasOne(d => d.ClassIdFkNavigation)
                    .WithMany(p => p.StudentsInClasses)
                    .HasForeignKey(d => d.ClassIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students___class__619B8048");

                entity.HasOne(d => d.StudentIdFkNavigation)
                    .WithMany(p => p.StudentsInClasses)
                    .HasForeignKey(d => d.StudentIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students___stude__60A75C0F");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
