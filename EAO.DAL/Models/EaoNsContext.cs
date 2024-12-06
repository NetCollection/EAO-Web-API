using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EAO.DAL.Models;

public partial class EaoNsContext : DbContext
{
    public EaoNsContext()
    {
    }

    public EaoNsContext(DbContextOptions<EaoNsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AlertBroadcast> AlertBroadcasts { get; set; }

    public virtual DbSet<AmbCar> AmbCars { get; set; }

    public virtual DbSet<AmbCarsBackup> AmbCarsBackups { get; set; }

    public virtual DbSet<AmbTeam> AmbTeams { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<Caller> Callers { get; set; }

    public virtual DbSet<CallersBackup> CallersBackups { get; set; }

    public virtual DbSet<DroppedCall> DroppedCalls { get; set; }

    public virtual DbSet<FailedJob> FailedJobs { get; set; }

    public virtual DbSet<FailedJobsSec> FailedJobsSecs { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<IncidentCategory> IncidentCategories { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobsSec> JobsSecs { get; set; }

    public virtual DbSet<JoinedTicket> JoinedTickets { get; set; }

    public virtual DbSet<JoinedTicketsBackup> JoinedTicketsBackups { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<Migration> Migrations { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientHistory> PatientHistories { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<RawDataPatient> RawDataPatients { get; set; }

    public virtual DbSet<RawDataView> RawDataViews { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionsGov> RegionsGovs { get; set; }

    public virtual DbSet<ServiceRecord> ServiceRecords { get; set; }

    public virtual DbSet<ServiceRecordHistory> ServiceRecordHistories { get; set; }

    public virtual DbSet<ServiceRecordsBackup> ServiceRecordsBackups { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SoothingHistory> SoothingHistories { get; set; }

    public virtual DbSet<Sqlmapoutput> Sqlmapoutputs { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticket20241007> Ticket20241007s { get; set; }

    public virtual DbSet<TicketsHistory> TicketsHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    public virtual DbSet<VFee> VFees { get; set; }

    public virtual DbSet<Vcall> Vcalls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.2.93.194;Initial Catalog=EAO_NS;User ID=CRM_All;Password=RCXDEVTeam@2024;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alerts__3213E83F3038ED37");

            entity.ToTable("alerts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alert1).HasColumnName("alert");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiredOn)
                .HasColumnType("datetime")
                .HasColumnName("expiredOn");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.ShallReadBy)
                .HasMaxLength(20)
                .HasDefaultValue("All")
                .HasColumnName("shall_read_by");
            entity.Property(e => e.ToParams).HasColumnName("to_params");
        });

        modelBuilder.Entity<AlertBroadcast>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alert_br__3213E83F6EB5A60E");

            entity.ToTable("alert_broadcast");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlertId).HasColumnName("alertId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ReadAt)
                .HasColumnType("datetime")
                .HasColumnName("read_at");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<AmbCar>(entity =>
        {
            entity.ToTable("amb_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CarCode)
                .HasMaxLength(20)
                .HasColumnName("car_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.GovId).HasColumnName("govId");
            entity.Property(e => e.IsSoothed).HasColumnName("is_soothed");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<AmbCarsBackup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__amb_cars__3213E83F7A85861B");

            entity.ToTable("amb_cars_Backup");

            entity.HasIndex(e => new { e.GovId, e.CarCode }, "NonClusteredIndex-20230329-141854");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("active");
            entity.Property(e => e.CarCode)
                .HasMaxLength(20)
                .HasColumnName("car_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.GovId).HasColumnName("govId");
            entity.Property(e => e.IsSoothed).HasColumnName("is_soothed");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<AmbTeam>(entity =>
        {
            entity.ToTable("amb_teams");

            entity.HasIndex(e => new { e.FullName, e.FirstName, e.Phone, e.Phone2, e.GovId }, "NonClusteredIndex-20230329-141956");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DayShift).HasDefaultValueSql("('0')");
            entity.Property(e => e.DefaultShift).HasDefaultValueSql("('0')");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.EaoId).HasColumnName("EAO_Id");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.GovId).HasColumnName("govId");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__answers__3213E83F48494517");

            entity.ToTable("answers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer1)
                .HasMaxLength(191)
                .HasColumnName("answer");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Qid).HasColumnName("qid");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("calls");

            entity.HasIndex(e => new { e.Id, e.CallerId }, "NonClusteredIndex-20230329-141256");

            entity.HasIndex(e => e.CallerId, "NonClusteredIndex-20230329-142122");

            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Caller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__callers__3213E83F433BDB03");

            entity.ToTable("callers");

            entity.HasIndex(e => new { e.CallerName, e.CallerPhone }, "NonClusteredIndex-20230329-141403");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallerName)
                .HasMaxLength(191)
                .HasColumnName("callerName");
            entity.Property(e => e.CallerOtherPhones)
                .HasMaxLength(30)
                .HasColumnName("callerOtherPhones");
            entity.Property(e => e.CallerPhone)
                .HasMaxLength(20)
                .HasColumnName("callerPhone");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CallersBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("callers_Backup");

            entity.Property(e => e.CallerName)
                .HasMaxLength(191)
                .HasColumnName("callerName");
            entity.Property(e => e.CallerOtherPhones)
                .HasMaxLength(30)
                .HasColumnName("callerOtherPhones");
            entity.Property(e => e.CallerPhone)
                .HasMaxLength(20)
                .HasColumnName("callerPhone");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<DroppedCall>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dropped_calls");

            entity.HasIndex(e => e.CallerId, "NonClusteredIndex-20240522-002016");

            entity.HasIndex(e => e.Id, "PK_calls_20240522-001928")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<FailedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__failed_j__3213E83F74ACC625");

            entity.ToTable("failed_jobs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection).HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
        });

        modelBuilder.Entity<FailedJobsSec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__failed_j__3213E83FC42724E6");

            entity.ToTable("failed_jobs_sec");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connection).HasColumnName("connection");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.FailedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("failed_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue).HasColumnName("queue");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.ToTable("fees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CollectorId).HasColumnName("collector_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.FeesStatus).HasColumnName("feesStatus");
            entity.Property(e => e.GroupNo)
                .HasMaxLength(60)
                .HasColumnName("group_no");
            entity.Property(e => e.ReceiptNo).HasColumnName("receipt_no");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TransDistinationAddr).HasMaxLength(191);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<IncidentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__incident__3213E83F3F157FD7");

            entity.ToTable("incident_categories");

            entity.HasIndex(e => new { e.Name, e.Parent }, "NonClusteredIndex-20230329-142208");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__jobs__3213E83F7CAB2C36");

            entity.ToTable("jobs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.AvailableAt).HasColumnName("available_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasMaxLength(191)
                .HasColumnName("queue");
            entity.Property(e => e.ReservedAt).HasColumnName("reserved_at");
        });

        modelBuilder.Entity<JobsSec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__jobs_sec__3213E83FF2786D8C");

            entity.ToTable("jobs_sec");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attempts).HasColumnName("attempts");
            entity.Property(e => e.AvailableAt).HasColumnName("available_at");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.Queue)
                .HasMaxLength(191)
                .HasColumnName("queue");
            entity.Property(e => e.ReservedAt).HasColumnName("reserved_at");
        });

        modelBuilder.Entity<JoinedTicket>(entity =>
        {
            entity.HasKey(e => new { e.Col1, e.Col2 }).HasName("joined_tickets_col1_col2_primary");

            entity.ToTable("joined_tickets");

            entity.Property(e => e.Col1).HasColumnName("col1");
            entity.Property(e => e.Col2).HasColumnName("col2");
        });

        modelBuilder.Entity<JoinedTicketsBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("joined_tickets_Backup");

            entity.Property(e => e.Col1).HasColumnName("col1");
            entity.Property(e => e.Col2).HasColumnName("col2");
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lookups__3213E83FFC67D001");

            entity.ToTable("lookups");

            entity.HasIndex(e => new { e.Name, e.Parent, e.Id }, "NonClusteredIndex-20230329-142245");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Parent).HasColumnName("parent");
            entity.Property(e => e.Type)
                .HasMaxLength(150)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Migration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__migratio__3213E83FCFCC39B6");

            entity.ToTable("migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.Migration1)
                .HasMaxLength(191)
                .HasColumnName("migration");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notes__3213E83FECF225DA");

            entity.ToTable("notes");

            entity.HasIndex(e => new { e.NoteType, e.TicketId }, "NonClusteredIndex-20230329-143210");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Note1).HasColumnName("note");
            entity.Property(e => e.NoteType)
                .HasMaxLength(60)
                .HasDefaultValue("Ticket")
                .HasColumnName("noteType");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patients__3213E83F17901C91");

            entity.ToTable("patients");

            entity.HasIndex(e => new { e.TicketId, e.ServiceId, e.FullName, e.FirstName, e.Nationality, e.Phone }, "NonClusteredIndex-20230329-142408");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(191)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.Dead).HasColumnName("dead");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.FirstName)
                .HasMaxLength(191)
                .HasColumnName("firstName");
            entity.Property(e => e.FullName)
                .HasMaxLength(191)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Hospital1)
                .HasMaxLength(191)
                .HasColumnName("hospital_1");
            entity.Property(e => e.Hospital2)
                .HasMaxLength(191)
                .HasColumnName("hospital_2");
            entity.Property(e => e.Hospital3)
                .HasMaxLength(191)
                .HasColumnName("hospital_3");
            entity.Property(e => e.Injured).HasColumnName("injured");
            entity.Property(e => e.MovedByPeople).HasColumnName("moved_by_people");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.NationalityId)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("nationality_id");
            entity.Property(e => e.Passport)
                .HasMaxLength(150)
                .IsFixedLength()
                .HasColumnName("passport");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.QAndA).HasColumnName("q_and_a");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TypeOfInjury)
                .HasMaxLength(150)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<PatientHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patient___3213E83FD3B777D4");

            entity.ToTable("patient_history");

            entity.HasIndex(e => new { e.PatientId, e.TicketId, e.ServiceId, e.FullName, e.FirstName, e.Nationality, e.Phone, e.CarCode }, "NonClusteredIndex-20230329-142523");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(191)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.FirstName)
                .HasMaxLength(191)
                .HasColumnName("firstName");
            entity.Property(e => e.FullName)
                .HasMaxLength(191)
                .HasColumnName("fullName");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Hospital1)
                .HasMaxLength(191)
                .HasColumnName("hospital_1");
            entity.Property(e => e.Hospital2)
                .HasMaxLength(191)
                .HasColumnName("hospital_2");
            entity.Property(e => e.Hospital3)
                .HasMaxLength(191)
                .HasColumnName("hospital_3");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.QAndA).HasColumnName("q_and_a");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__question__3213E83FB993FA02");

            entity.ToTable("questions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AllowMultiple).HasColumnName("allowMultiple");
            entity.Property(e => e.ApplicableFor).HasColumnName("applicableFor");
            entity.Property(e => e.Condition)
                .HasMaxLength(191)
                .HasColumnName("condition");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Format)
                .HasMaxLength(255)
                .HasColumnName("format");
            entity.Property(e => e.Instructions)
                .HasMaxLength(191)
                .HasColumnName("instructions");
            entity.Property(e => e.Question1)
                .HasMaxLength(191)
                .HasColumnName("question");
        });

        modelBuilder.Entity<RawDataPatient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("raw_data_patient");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.CallSource).HasColumnName("callSource");
            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CallerName)
                .HasMaxLength(191)
                .HasColumnName("callerName");
            entity.Property(e => e.CallerOtherPhones)
                .HasMaxLength(30)
                .HasColumnName("callerOtherPhones");
            entity.Property(e => e.CallerPhone)
                .HasMaxLength(20)
                .HasColumnName("callerPhone");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CarGov).HasColumnName("car_gov");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CollectorId).HasColumnName("collector_id");
            entity.Property(e => e.Cst).HasColumnName("cst");
            entity.Property(e => e.Ct).HasColumnName("ct");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(150)
                .HasColumnName("driver_name");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.FeesStatus).HasColumnName("feesStatus");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(250)
                .HasColumnName("incidentLocation");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.ParamedicId).HasColumnName("paramedic_id");
            entity.Property(e => e.ParamedicName)
                .HasMaxLength(150)
                .HasColumnName("paramedic_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientName)
                .HasMaxLength(191)
                .HasColumnName("patient_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.ReceiptNo).HasColumnName("receipt_no");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.TicketCreation)
                .HasColumnType("datetime")
                .HasColumnName("ticket_creation");
            entity.Property(e => e.TicketDealing)
                .HasMaxLength(20)
                .HasColumnName("ticket_dealing");
            entity.Property(e => e.TicketGov).HasColumnName("ticket_gov");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TicketLastUpd)
                .HasColumnType("datetime")
                .HasColumnName("ticket_last_upd");
            entity.Property(e => e.TicketStatus).HasColumnName("ticket_status");
            entity.Property(e => e.TicketStatusEnd).HasColumnName("ticket_status_end");
            entity.Property(e => e.TransDistinationAddr).HasMaxLength(191);
        });

        modelBuilder.Entity<RawDataView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("raw_data_view");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.CallSource).HasColumnName("callSource");
            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CallerName)
                .HasMaxLength(191)
                .HasColumnName("callerName");
            entity.Property(e => e.CallerOtherPhones)
                .HasMaxLength(30)
                .HasColumnName("callerOtherPhones");
            entity.Property(e => e.CallerPhone)
                .HasMaxLength(20)
                .HasColumnName("callerPhone");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CarGov).HasColumnName("car_gov");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CollectorId).HasColumnName("collector_id");
            entity.Property(e => e.Cst).HasColumnName("cst");
            entity.Property(e => e.Ct).HasColumnName("ct");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.DriverName)
                .HasMaxLength(150)
                .HasColumnName("driver_name");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.FeesStatus).HasColumnName("feesStatus");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(250)
                .HasColumnName("incidentLocation");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.ParamedicId).HasColumnName("paramedic_id");
            entity.Property(e => e.ParamedicName)
                .HasMaxLength(150)
                .HasColumnName("paramedic_name");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PatientName)
                .HasMaxLength(191)
                .HasColumnName("patient_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.ReceiptNo).HasColumnName("receipt_no");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.TicketCreation)
                .HasColumnType("datetime")
                .HasColumnName("ticket_creation");
            entity.Property(e => e.TicketDealing)
                .HasMaxLength(20)
                .HasColumnName("ticket_dealing");
            entity.Property(e => e.TicketGov).HasColumnName("ticket_gov");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TicketLastUpd)
                .HasColumnType("datetime")
                .HasColumnName("ticket_last_upd");
            entity.Property(e => e.TicketStatus).HasColumnName("ticket_status");
            entity.Property(e => e.TicketStatusEnd).HasColumnName("ticket_status_end");
            entity.Property(e => e.TransDistinationAddr).HasMaxLength(191);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("regions");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("name_ar");
        });

        modelBuilder.Entity<RegionsGov>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("regions_govs");

            entity.Property(e => e.GovId).HasColumnName("gov_id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
        });

        modelBuilder.Entity<ServiceRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F8BAE6DC5");

            entity.ToTable("service_records");

            entity.HasIndex(e => new { e.AmbCarId, e.CarCode, e.TicketId, e.DriverId, e.DeletedAt }, "NonClusteredIndex-20230329-142923");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmbCarId).HasColumnName("ambCar_id");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CounterEnd).HasColumnName("counter_end");
            entity.Property(e => e.CounterStart).HasColumnName("counter_start");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.ParamedicId).HasColumnName("paramedic_id");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<ServiceRecordHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F559FFD78");

            entity.ToTable("service_record_history");

            entity.HasIndex(e => new { e.AmbCarId, e.TicketId, e.CarCode, e.DriverId }, "NonClusteredIndex-20230329-142736");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmbCarId).HasColumnName("ambCar_id");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CounterEnd).HasColumnName("counter_end");
            entity.Property(e => e.CounterStart).HasColumnName("counter_start");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.ParamedicId).HasColumnName("paramedic_id");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<ServiceRecordsBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("service_records_Backup");

            entity.Property(e => e.AmbCarId).HasColumnName("ambCar_id");
            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CounterEnd).HasColumnName("counter_end");
            entity.Property(e => e.CounterStart).HasColumnName("counter_start");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.End)
                .HasColumnType("datetime")
                .HasColumnName("end");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ParamedicId).HasColumnName("paramedic_id");
            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("sessions");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.LastActivity).HasColumnName("last_activity");
            entity.Property(e => e.Payload).HasColumnName("payload");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<SoothingHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("soothing_history");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.RawData)
                .HasColumnType("text")
                .HasColumnName("raw_data");
            entity.Property(e => e.SoothingDate).HasColumnName("soothing_date");
        });

        modelBuilder.Entity<Sqlmapoutput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SQLMAPOU__3214EC270D48F05C");

            entity.ToTable("SQLMAPOUTPUT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Data)
                .HasMaxLength(4000)
                .HasColumnName("DATA");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("tickets", tb => tb.HasTrigger("setDailySno"));

            entity.HasIndex(e => new { e.CallSource, e.Area, e.Governorate, e.CaseType, e.CaseSubType, e.NoticeStatus, e.DailySno, e.DisconnectCall, e.FollowUp, e.NoticeStatusEnd }, "NonClusteredIndex-20230329-141542");

            entity.HasIndex(e => e.CallerId, "NonClusteredIndex-20240522-000720");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.CallConvertComment).HasMaxLength(150);
            entity.Property(e => e.CallConvertReason).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CallSource).HasColumnName("callSource");
            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CaseSubType).HasColumnName("caseSubType");
            entity.Property(e => e.CaseType).HasColumnName("caseType");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DailySno).HasColumnName("daily_sno");
            entity.Property(e => e.DealingStatus)
                .HasMaxLength(20)
                .HasColumnName("dealingStatus");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Eaocode)
                .HasMaxLength(60)
                .HasColumnName("EAOCode");
            entity.Property(e => e.Governorate).HasColumnName("governorate");
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(250)
                .HasColumnName("incidentLocation");
            entity.Property(e => e.NoticeStatus).HasColumnName("noticeStatus");
            entity.Property(e => e.NoticeStatusEnd).HasColumnName("noticeStatusEnd");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.QAndA).HasColumnName("q_and_a");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Ticket20241007>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ticket20241007");

            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.CallConvertComment).HasMaxLength(150);
            entity.Property(e => e.CallSource).HasColumnName("callSource");
            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CaseSubType).HasColumnName("caseSubType");
            entity.Property(e => e.CaseType).HasColumnName("caseType");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DailySno).HasColumnName("daily_sno");
            entity.Property(e => e.DealingStatus)
                .HasMaxLength(20)
                .HasColumnName("dealingStatus");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Eaocode)
                .HasMaxLength(60)
                .HasColumnName("EAOCode");
            entity.Property(e => e.Governorate).HasColumnName("governorate");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(250)
                .HasColumnName("incidentLocation");
            entity.Property(e => e.NoticeStatus).HasColumnName("noticeStatus");
            entity.Property(e => e.NoticeStatusEnd).HasColumnName("noticeStatusEnd");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.QAndA).HasColumnName("q_and_a");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<TicketsHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tickets___3213E83FB41FBC65");

            entity.ToTable("tickets_histories");

            entity.HasIndex(e => new { e.TicketId, e.CallSource, e.Area, e.Governorate }, "NonClusteredIndex-20230329-141043");

            entity.HasIndex(e => e.CallerId, "NonClusteredIndex-20240522-001156");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.CallConvertComment).HasMaxLength(150);
            entity.Property(e => e.CallConvertReason).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.CallSource).HasColumnName("callSource");
            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CaseSubType).HasColumnName("caseSubType");
            entity.Property(e => e.CaseType).HasColumnName("caseType");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DailySno).HasColumnName("daily_sno");
            entity.Property(e => e.DealingStatus)
                .HasMaxLength(20)
                .HasColumnName("dealingStatus");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DisconnectCall).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Eaocode)
                .HasMaxLength(60)
                .HasColumnName("EAOCode");
            entity.Property(e => e.FollowUp).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Governorate).HasColumnName("governorate");
            entity.Property(e => e.IncidentLocation)
                .HasMaxLength(250)
                .HasColumnName("incidentLocation");
            entity.Property(e => e.NoticeStatus).HasColumnName("noticeStatus");
            entity.Property(e => e.NoticeStatusEnd).HasColumnName("noticeStatusEnd");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.QAndA).HasColumnName("q_and_a");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F326588FD");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("('1')")
                .HasColumnName("active");
            entity.Property(e => e.ArName)
                .HasMaxLength(191)
                .HasColumnName("ar_name");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.GovId).HasColumnName("govId");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RegionId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("regionId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users_ro__3213E83F49AF1260");

            entity.ToTable("users_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Permissions).HasColumnName("permissions");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .HasColumnName("role");
        });

        modelBuilder.Entity<VFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vFees");

            entity.Property(e => e.CarCode).HasColumnName("car_code");
            entity.Property(e => e.CarGov).HasColumnName("car_gov");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CollectorId).HasColumnName("collector_id");
            entity.Property(e => e.CounterEnd).HasColumnName("counter_end");
            entity.Property(e => e.CounterStart).HasColumnName("counter_start");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(60)
                .HasColumnName("createdBy");
            entity.Property(e => e.DriverName)
                .HasMaxLength(150)
                .HasColumnName("driver_name");
            entity.Property(e => e.FeesId).HasColumnName("fees_id");
            entity.Property(e => e.FeesStatus).HasColumnName("feesStatus");
            entity.Property(e => e.ReceiptNo).HasColumnName("receipt_no");
            entity.Property(e => e.ServiceEndedAt)
                .HasColumnType("datetime")
                .HasColumnName("service_ended_at");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.ServiceStartAt)
                .HasColumnType("datetime")
                .HasColumnName("service_start_at");
            entity.Property(e => e.TicketGov).HasColumnName("ticket_gov");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.TransDistinationAddr).HasMaxLength(191);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .HasColumnName("updatedBy");
        });

        modelBuilder.Entity<Vcall>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VCalls");

            entity.Property(e => e.CallerId).HasColumnName("callerId");
            entity.Property(e => e.CallerName)
                .HasMaxLength(191)
                .HasColumnName("callerName");
            entity.Property(e => e.CallerPhone)
                .HasMaxLength(20)
                .HasColumnName("callerPhone");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("createdBy");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastCallStatus)
                .HasMaxLength(50)
                .HasColumnName("lastCallStatus");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
