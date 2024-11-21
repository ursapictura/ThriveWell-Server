using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThriveWell.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Entry = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SeverityAverage = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyJournals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Triggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triggers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SymptomId = table.Column<int>(type: "integer", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SymptomLogs_Symptoms_SymptomId",
                        column: x => x.SymptomId,
                        principalTable: "Symptoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SymptomTriggers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SymptomLogId = table.Column<int>(type: "integer", nullable: false),
                    SymptomSeverity = table.Column<int>(type: "integer", nullable: false),
                    TriggerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomTriggers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SymptomTriggers_SymptomLogs_SymptomLogId",
                        column: x => x.SymptomLogId,
                        principalTable: "SymptomLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SymptomTriggers_Triggers_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Triggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DailyJournals",
                columns: new[] { "Id", "Date", "Entry", "SeverityAverage", "Uid" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 11, 1), "Feeling pretty rough today. My joints are aching more than usual, especially in my knees and wrists. I’m also feeling fatigued, like I haven’t had enough sleep even though I did rest well. I had a mild headache earlier, but it faded after I drank some water. The pain is worse in the morning, but it gets a little better in the afternoon. Still, I’m not sure I have the energy to do much. Trying to take it easy today.", null, "NSkdshfjdfajdsh97834" },
                    { 2, new DateOnly(2024, 11, 2), "Woke up feeling surprisingly better today. The joint pain is still there, but it’s more manageable. My energy levels seem higher, so I managed to get some housework done. My stomach was a little upset this morning, but I think it was just from the stress of yesterday. I didn’t have any headaches today, and I even went for a short walk outside. I feel optimistic, hoping this trend continues.", null, "NSkdshfjdfajdsh97834" },
                    { 3, new DateOnly(2024, 11, 3), "Worse than yesterday. My joints are stiff and swollen this morning, and my energy is back to zero. Even simple tasks like getting dressed felt like a challenge. I had a mild fever in the afternoon, and I ended up resting for most of the day. I’m feeling a bit down, honestly. I’m trying to stay hydrated and eat well, but it’s hard to focus on much. Hoping tomorrow’s better.", null, "NSkdshfjdfajdsh97834" },
                    { 4, new DateOnly(2024, 11, 4), "A bit of an improvement today. I still have joint pain, but it’s more of a dull ache rather than sharp discomfort. My energy came back in the afternoon, and I was able to cook dinner without feeling exhausted. No headaches, which is a relief. The only real symptom lingering is some light brain fog. I’m hoping it’ll clear up soon. I’m trying to stay active without overdoing it.", null, "NSkdshfjdfajdsh97834" },
                    { 5, new DateOnly(2024, 11, 5), "The morning started off okay, but by late afternoon, I felt completely wiped out. My muscles are sore, and I’ve had a persistent headache all day. I had to take a nap, which helped a bit, but I’m still drained. I’m frustrated because I was doing so much better a couple of days ago. My stomach feels a little off too. I’m trying not to panic, but it’s hard not to worry when things swing like this.", null, "NSkdshfjdfajdsh97834" },
                    { 6, new DateOnly(2024, 11, 6), "Better day today, thankfully. The pain in my joints is almost gone, and I have more energy than I’ve had all week. I was able to get out of the house for a few errands, and it felt nice to feel “normal” for a change. No headache or nausea, and my mood is improved too. I’m keeping my fingers crossed that this is a sign of recovery. I’ll take it easy tonight, though, just in case.", null, "NSkdshfjdfajdsh97834" },
                    { 7, new DateOnly(2024, 11, 8), "A setback today. I woke up with swollen hands and feet, and my fatigue hit hard early. I feel like I can’t get comfortable, no matter what I do. I had a minor flare-up of muscle pain, and I just want to lie down. I’m frustrated and wondering if something triggered this. Trying not to spiral, but it’s tough. I’ll be more mindful of my diet and hydration tomorrow.", null, "NSkdshfjdfajdsh97834" },
                    { 8, new DateOnly(2024, 11, 9), "A much-needed reprieve today. My joints feel almost normal again, and I’ve got some energy. I even went for a short walk, which I haven’t been able to do in days. I had a little bit of brain fog this morning, but it cleared up by mid-afternoon. I’ve been trying to stick to my routine with medication and diet, so I’m relieved to see some improvement. I feel hopeful but cautious.", null, "NSkdshfjdfajdsh97834" },
                    { 9, new DateOnly(2024, 11, 10), "Not great today. I woke up feeling stiff and had a headache by midday. My muscles are sore, and I can’t seem to shake the fatigue. It’s a bit of a struggle to focus on work. I’m going to rest as much as possible, but I’m getting frustrated with the unpredictability of it all. I’m not sure what’s triggering these fluctuations. I’m trying to stay positive, but it’s hard.", null, "NSkdshfjdfajdsh97834" },
                    { 10, new DateOnly(2024, 11, 12), "A mixed day. The morning was okay—no new flare-ups or unusual pain—but by the afternoon, I started feeling achy again. My stomach’s been a bit off, and I’m worried that might be affecting how I’m feeling. I took a few breaks throughout the day to rest, but my energy levels still feel low. I’m hoping a good night’s sleep will help reset things. Trying not to let the ups and downs get to me too much.", null, "NSkdshfjdfajdsh97834" },
                    { 11, new DateOnly(2024, 11, 1), "Feeling kind of off today. I woke up with a sore throat, which is odd for me. It’s not like a cold—more like something is inflamed in there. I also noticed some swelling in my hands and ankles this morning, which worries me. It’s been a while since I’ve had any swelling like that, so I’m taking it easy. My energy is really low, and I’ve been trying to rest as much as I can, but I’m still exhausted. I don’t know if I should be concerned yet or just wait it out. Hoping it’s nothing serious.", null, "KJHKBdskdaksjde9458v" },
                    { 12, new DateOnly(2024, 11, 2), "The swelling is worse today, and now I’m having trouble moving my fingers without pain. It’s frustrating, especially since I had plans to get some work done. I’ve been feeling really nauseous off and on as well, which is new. My throat is still sore, but not as much as yesterday. I’m trying to stay hydrated and keep my stress levels down, but it’s hard when my body feels like it’s in revolt. I have an appointment with my doctor tomorrow, so I’m hoping they can give me some clarity.", null, "KJHKBdskdaksjde9458v" },
                    { 13, new DateOnly(2024, 11, 3), "Doctor's appointment went well, though they weren’t sure what triggered this flare-up. I was given a corticosteroid for the inflammation, and it’s already helping with the swelling in my hands. I still feel a little off—nausea hasn’t completely gone away, and I’m tired—but at least I’m seeing some improvement. My doctor mentioned it might take a few more days to feel fully back to normal. I’m grateful for the medication, but I don’t want to rely on it too much. For now, I’m focusing on getting better, one step at a time.", null, "KJHKBdskdaksjde9458v" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "Name", "Uid" },
                values: new object[,]
                {
                    { 1, "Joint Pain", "NSkdshfjdfajdsh97834" },
                    { 2, "Fatigue", "NSkdshfjdfajdsh97834" },
                    { 3, "Swelling", "NSkdshfjdfajdsh97834" },
                    { 4, "Headache", "NSkdshfjdfajdsh97834" },
                    { 5, "Brain Fog", "NSkdshfjdfajdsh97834" },
                    { 6, "Muscle Pain", "NSkdshfjdfajdsh97834" },
                    { 7, "Nausea", "NSkdshfjdfajdsh97834" },
                    { 8, "Fever", "NSkdshfjdfajdsh97834" },
                    { 9, "Stomach Upset", "NSkdshfjdfajdsh97834" },
                    { 10, "Sore Throat", "NSkdshfjdfajdsh97834" },
                    { 11, "Swelling", "KJHKBdskdaksjde9458v" },
                    { 12, "Fatigue", "KJHKBdskdaksjde9458v" },
                    { 13, "Nausea", "KJHKBdskdaksjde9458v" },
                    { 14, "Headache", "KJHKBdskdaksjde9458v" },
                    { 15, "Sore Throat", "KJHKBdskdaksjde9458v" },
                    { 16, "Brain Fog", "KJHKBdskdaksjde9458v" },
                    { 17, "Muscle Pain", "KJHKBdskdaksjde9458v" },
                    { 18, "Stomach Upset", "KJHKBdskdaksjde9458v" },
                    { 19, "Fever", "KJHKBdskdaksjde9458v" }
                });

            migrationBuilder.InsertData(
                table: "Triggers",
                columns: new[] { "Id", "Name", "Uid" },
                values: new object[,]
                {
                    { 1, "Cold Weather", "NSkdshfjdfajdsh97834" },
                    { 2, "Hot Weather", "NSkdshfjdfajdsh97834" },
                    { 3, "Lack of Sleep", "NSkdshfjdfajdsh97834" },
                    { 4, "Overexertion", "NSkdshfjdfajdsh97834" },
                    { 5, "Infection/Illness", "NSkdshfjdfajdsh97834" },
                    { 6, "Stress", "NSkdshfjdfajdsh97834" },
                    { 7, "Physical Injury", "NSkdshfjdfajdsh97834" },
                    { 8, "Flu Vaccination", "NSkdshfjdfajdsh97834" },
                    { 9, "Hormonal Changes", "NSkdshfjdfajdsh97834" },
                    { 10, "Cold Weather", "NSkdshfjdfajdsh97834" },
                    { 11, "Gluten", "NSkdshfjdfajdsh97834" },
                    { 12, "Dairy", "NSkdshfjdfajdsh97834" },
                    { 13, "Nightshades: Tomatoes, Eggplant, Peppers", "NSkdshfjdfajdsh97834" },
                    { 14, "Dehydration", "NSkdshfjdfajdsh97834" },
                    { 15, "Caffeine", "NSkdshfjdfajdsh97834" },
                    { 16, "New Laundry Detergent", "KJHKBdskdaksjde9458v" },
                    { 17, "New Lotion/Skincare Products", "KJHKBdskdaksjde9458v" },
                    { 18, "Lack of Exercise", "KJHKBdskdaksjde9458v" },
                    { 19, "Smoking", "KJHKBdskdaksjde9458v" },
                    { 20, "Alcohol Consumption", "KJHKBdskdaksjde9458v" }
                });

            migrationBuilder.InsertData(
                table: "SymptomLogs",
                columns: new[] { "Id", "Date", "Severity", "SymptomId", "Uid" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 11, 1), 3, 1, "NSkdshfjdfajdsh97834" },
                    { 2, new DateOnly(2024, 11, 1), 4, 2, "NSkdshfjdfajdsh97834" },
                    { 3, new DateOnly(2024, 11, 2), 2, 1, "NSkdshfjdfajdsh97834" },
                    { 4, new DateOnly(2024, 11, 2), 3, 3, "NSkdshfjdfajdsh97834" },
                    { 5, new DateOnly(2024, 11, 3), 4, 6, "NSkdshfjdfajdsh97834" },
                    { 6, new DateOnly(2024, 11, 3), 3, 4, "NSkdshfjdfajdsh97834" },
                    { 7, new DateOnly(2024, 11, 4), 2, 5, "NSkdshfjdfajdsh97834" },
                    { 8, new DateOnly(2024, 11, 4), 1, 7, "NSkdshfjdfajdsh97834" },
                    { 9, new DateOnly(2024, 11, 5), 3, 1, "NSkdshfjdfajdsh97834" },
                    { 10, new DateOnly(2024, 11, 5), 3, 2, "NSkdshfjdfajdsh97834" },
                    { 11, new DateOnly(2024, 11, 6), 2, 4, "NSkdshfjdfajdsh97834" },
                    { 12, new DateOnly(2024, 11, 6), 1, 3, "NSkdshfjdfajdsh97834" },
                    { 13, new DateOnly(2024, 11, 8), 2, 8, "NSkdshfjdfajdsh97834" },
                    { 14, new DateOnly(2024, 11, 8), 4, 2, "NSkdshfjdfajdsh97834" },
                    { 15, new DateOnly(2024, 11, 9), 1, 1, "NSkdshfjdfajdsh97834" },
                    { 16, new DateOnly(2024, 11, 9), 3, 5, "NSkdshfjdfajdsh97834" },
                    { 17, new DateOnly(2024, 11, 10), 4, 6, "NSkdshfjdfajdsh97834" },
                    { 18, new DateOnly(2024, 11, 10), 3, 4, "NSkdshfjdfajdsh97834" },
                    { 19, new DateOnly(2024, 11, 12), 2, 3, "NSkdshfjdfajdsh97834" },
                    { 20, new DateOnly(2024, 11, 12), 3, 7, "NSkdshfjdfajdsh97834" },
                    { 21, new DateOnly(2024, 11, 1), 3, 11, "KJHKBdskdaksjde9458v" },
                    { 22, new DateOnly(2024, 11, 2), 2, 12, "KJHKBdskdaksjde9458v" },
                    { 23, new DateOnly(2024, 11, 3), 4, 13, "KJHKBdskdaksjde9458v" },
                    { 24, new DateOnly(2024, 11, 4), 3, 14, "KJHKBdskdaksjde9458v" },
                    { 25, new DateOnly(2024, 11, 5), 1, 15, "KJHKBdskdaksjde9458v" },
                    { 26, new DateOnly(2024, 11, 6), 2, 16, "KJHKBdskdaksjde9458v" },
                    { 27, new DateOnly(2024, 11, 8), 3, 17, "KJHKBdskdaksjde9458v" },
                    { 28, new DateOnly(2024, 11, 9), 4, 18, "KJHKBdskdaksjde9458v" },
                    { 29, new DateOnly(2024, 11, 10), 2, 19, "KJHKBdskdaksjde9458v" },
                    { 30, new DateOnly(2024, 11, 12), 3, 19, "KJHKBdskdaksjde9458v" }
                });

            migrationBuilder.InsertData(
                table: "SymptomTriggers",
                columns: new[] { "Id", "SymptomLogId", "SymptomSeverity", "TriggerId" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 2, 2, 6 },
                    { 3, 3, 4, 5 },
                    { 4, 4, 2, 14 },
                    { 5, 5, 3, 4 },
                    { 6, 6, 1, 3 },
                    { 7, 7, 4, 6 },
                    { 8, 8, 2, 2 },
                    { 9, 9, 3, 4 },
                    { 10, 10, 3, 14 },
                    { 11, 11, 1, 13 },
                    { 12, 12, 2, 6 },
                    { 13, 13, 4, 5 },
                    { 14, 14, 3, 8 },
                    { 15, 15, 3, 7 },
                    { 16, 16, 2, 15 },
                    { 17, 17, 4, 6 },
                    { 18, 18, 3, 5 },
                    { 19, 19, 2, 14 },
                    { 20, 20, 3, 1 },
                    { 21, 21, 3, 16 },
                    { 22, 22, 2, 17 },
                    { 23, 23, 4, 19 },
                    { 24, 24, 3, 18 },
                    { 25, 25, 1, 20 },
                    { 26, 26, 2, 16 },
                    { 27, 27, 3, 19 },
                    { 28, 28, 4, 18 },
                    { 29, 29, 2, 20 },
                    { 30, 30, 3, 16 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SymptomLogs_SymptomId",
                table: "SymptomLogs",
                column: "SymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomTriggers_SymptomLogId",
                table: "SymptomTriggers",
                column: "SymptomLogId");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomTriggers_TriggerId",
                table: "SymptomTriggers",
                column: "TriggerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyJournals");

            migrationBuilder.DropTable(
                name: "SymptomTriggers");

            migrationBuilder.DropTable(
                name: "SymptomLogs");

            migrationBuilder.DropTable(
                name: "Triggers");

            migrationBuilder.DropTable(
                name: "Symptoms");
        }
    }
}
