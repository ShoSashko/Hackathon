using Microsoft.EntityFrameworkCore;
using VideoService.Data.Entities;
using VideoService.Data.JSONParser;

namespace VideoService.DB.Migrations.Contexts
{
    public class VideoServiceDbContext : DbContext
    {
        public const string SCHEMA = "dbo";

        public VideoServiceDbContext(DbContextOptions<VideoServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Flow> Flows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var data = Parser.ParseFileContent();

            modelBuilder.Entity<User>().HasData(data.Users);
            modelBuilder.Entity<Video>().HasData(data.Videos);
            modelBuilder.Entity<Flow>().HasData(data.Flows);
            modelBuilder.Entity<Group>().HasData(data.Groups);

            modelBuilder.Entity<UsersToVideos>()
                .HasKey(t => new { t.UserId, t.VideoId });

            modelBuilder.Entity<UsersToVideos>()
                .HasOne(uv => uv.User)
                .WithMany(u => u.UsersToVideos)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UsersToVideos>()
                .HasOne(uv => uv.Video)
                .WithMany(u => u.UsersToVideos)
                .HasForeignKey(u => u.VideoId);

            modelBuilder.Entity<UsersToVideos>()
                .HasData(data.UsersToVideos);

            modelBuilder.Entity<UsersToGroups>()
                .HasKey(t => new { t.UserId, t.GroupId });

            modelBuilder.Entity<UsersToGroups>()
                .HasOne(uv => uv.User)
                .WithMany(u => u.UsersToGroups)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UsersToGroups>()
                .HasOne(uv => uv.Group)
                .WithMany(u => u.UsersToGroups)
                .HasForeignKey(u => u.GroupId);

            modelBuilder.Entity<UsersToGroups>()
                .HasData(data.UsersToGroups);

            modelBuilder.Entity<UsersToFlows>()
                .HasKey(t => new { t.UserId, t.FlowId });

            modelBuilder.Entity<UsersToFlows>()
                .HasOne(uv => uv.User)
                .WithMany(u => u.UsersToFlows)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UsersToFlows>()
                .HasOne(uv => uv.Flow)
                .WithMany(u => u.UsersToFlows)
                .HasForeignKey(u => u.FlowId);

            modelBuilder.Entity<UsersToFlows>()
                .HasData(data.UsersToFlows);

            modelBuilder.Entity<GroupsToVideos>()
                .HasKey(t => new { t.VideoId, t.GroupId });

            modelBuilder.Entity<GroupsToVideos>()
                .HasOne(uv => uv.Group)
                .WithMany(u => u.GroupsToVideos)
                .HasForeignKey(u => u.GroupId);

            modelBuilder.Entity<GroupsToVideos>()
                .HasOne(uv => uv.Video)
                .WithMany(u => u.GroupsToVideos)
                .HasForeignKey(u => u.VideoId);

            modelBuilder.Entity<GroupsToVideos>()
                .HasData(data.GroupsToVideos);

            modelBuilder.Entity<GroupsToFlows>()
                .HasKey(t => new { t.FlowId, t.GroupId });

            modelBuilder.Entity<GroupsToFlows>()
                .HasOne(uv => uv.Flow)
                .WithMany(u => u.GroupsToFlows)
                .HasForeignKey(u => u.FlowId);

            modelBuilder.Entity<GroupsToFlows>()
                .HasOne(uv => uv.Group)
                .WithMany(u => u.GroupsToFlows)
                .HasForeignKey(u => u.GroupId);

            modelBuilder.Entity<GroupsToFlows>()
                .HasData(data.GroupsToFlows);

            modelBuilder.Entity<FlowsToVideos>()
                .HasKey(t => new { t.FlowId, t.VideoId });

            modelBuilder.Entity<FlowsToVideos>()
                .HasOne(uv => uv.Flow)
                .WithMany(u => u.FlowsToVideos)
                .HasForeignKey(u => u.FlowId);

            modelBuilder.Entity<FlowsToVideos>()
                .HasOne(uv => uv.Video)
                .WithMany(u => u.FlowsToVideos)
                .HasForeignKey(u => u.VideoId);

            modelBuilder.Entity<FlowsToVideos>()
                .HasData(data.FlowsToVideos);

            base.OnModelCreating(modelBuilder);
        }
    }
}