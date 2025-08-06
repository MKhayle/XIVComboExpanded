using System.Numerics;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Style;
using Dalamud.Interface.Windowing;
using XIVComboExpandedPlugin;

namespace XIVComboExpanded.Interface
{
    public class OneTimeModal : Window
    {

        private readonly XIVComboExpandedPlugin.XIVComboExpandedPlugin Plugin;

        public OneTimeModal(XIVComboExpandedPlugin.XIVComboExpandedPlugin Plugin)
        : base("popup")
        {
            this.Plugin = Plugin;
            this.RespectCloseHotkey = false;
            this.AllowPinning = false;
            this.ShowCloseButton = false;
            this.Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoTitleBar;
            this.Size = new Vector2(480, 500);
            this.SizeCondition = ImGuiCond.Always;
        }

        public override bool DrawConditions()
        {
            if (Service.Configuration is { OneTimePopUp: true }) return true;
            return false;
        }

        /// <inheritdoc/>
        public override void Draw()
        {

            ImGui.PushFont(UiBuilder.MonoFont);
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
            ImGui.Text($"Welcome to XIVCombo Expanded v{Service.Interface.Manifest.AssemblyVersion}!");
            ImGui.PopStyleColor();
            ImGui.PopFont();
            ImGui.Spacing();
            ImGui.Text("This is the first time you're using the new version of XIVCombo Expanded.");
            ImGui.Text("With the introduction of new combos and features, an ever-growing list of jobs,\nthis plugin ended up having to be reworked for better UI & clarity.");
            ImGui.Text("First of all, it is recommended to open up the main interface and check it out.");
            ImGui.Spacing();
            ImGui.Spacing();

            if (ImGui.Button("Open the Main Interface"))
            {
                this.Plugin.configWindow.Toggle();
                Service.Configuration.Save();
            }

            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
            ImGui.Text("What's new?");
            ImGui.PopStyleColor();
            ImGui.Spacing();
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
            ImGui.Text("Combo categories: Classic, Expanded, Accessibility and Secrets.");
            ImGui.PopStyleColor();
            ImGui.BulletText("Classic mirrors the Vanilla XIVCombo features.");
            ImGui.BulletText("Expanded follows the set of rules that XIVCombo Expanded used to follow.");
            ImGui.BulletText("Accessibility adds previously hidden features which aim at increasing\naccessibility for every player and remove more buttons.");
            ImGui.BulletText("Secrets adds the rest of the previously hidden features which were\neither unintuitive or forcing specific rotations for small benefits.");
            ImGui.Spacing();
            ImGui.BulletText("Note: Each combo category requires the previous one to be enabled.");
            ImGui.Spacing();
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
            ImGui.Text("New UI & settings");
            ImGui.PopStyleColor();
            ImGui.BulletText("You can check them out below, actually. How neat!");
            ImGui.BulletText("By default, icons are small for low-resolution users.\n2k & 4k enjoyers have options for bigger icons.");
            ImGui.BulletText("Icons may cause a loss of FPS when the Combos tab is open.\nThat shouldn't happen when it matters, right?");

            ImGui.Spacing();
            ImGui.Text("Please set up your ideal configuration.\nDo not worry, you will be able to change those later.");

            ImGui.Spacing();
            ImGui.Separator();
            ImGui.Spacing();

            ImGuiWindowFlags window_flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.ChildWindow;
            ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 5f);
            ImGui.BeginChild("ModalSettings", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 180f), true, window_flags);

            ImGui.PushFont(UiBuilder.MonoFont);
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
            ImGui.Text($"General options");
            ImGui.PopStyleColor();
            ImGui.PopFont();
            ImGui.Separator();

            var autoJobChange = Service.Configuration.AutoJobChange;
            if (ImGui.Checkbox("Automatically switch to your current job's tab upon opening the UI.", ref autoJobChange))
            {
                Service.Configuration.AutoJobChange = autoJobChange;
                Service.Configuration.Save();
            }

            var bigComboIcons = Service.Configuration.BigComboIcons;
            if (ImGui.Checkbox("Increase the size of icons for combos and features.", ref bigComboIcons))
            {
                Service.Configuration.BigComboIcons = bigComboIcons;
                Service.Configuration.Save();
            }

            var bigJobIcons = Service.Configuration.BigJobIcons;
            if (ImGui.Checkbox("Increase the size of icons for the jobs on the side bar.", ref bigJobIcons))
            {
                Service.Configuration.BigJobIcons = bigJobIcons;
                Service.Configuration.Save();

            }

            var enableTheme = Service.Configuration.EnableTheme;
            if (ImGui.Checkbox("Enforce the custom theme.", ref enableTheme))
            {
                Service.Configuration.EnableTheme = enableTheme;
                Service.Configuration.Save();
            }

            var hideIcons = Service.Configuration.HideIcons;
            if (ImGui.Checkbox("Hide icons for combos and features.", ref hideIcons))
            {
                Service.Configuration.HideIcons = hideIcons;
                Service.Configuration.Save();
            }

            ImGui.EndChild();
            ImGui.PopStyleVar();

            ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 5f);
            ImGui.BeginChild("ChildR", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 155f), true, window_flags);

            ImGui.PushFont(UiBuilder.MonoFont);
            ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.TankBlue);
            ImGui.Text($"Expanded Combos");
            ImGui.PopStyleColor();
            ImGui.PopFont();
            ImGui.Separator();

            ImGui.BulletText("Those combos are additional features absent in original XIVCombo.");
            ImGui.BulletText("They usually aim at further reducing button bloating.");
            ImGui.BulletText("They are also designed to bring QoL improvements to some jobs.");
            ImGui.BulletText("They are meant to be used by anyone, whatever their reasons may be.");

            ImGui.Separator();

            var showExpanded = Service.Configuration.EnableExpandedCombos;
            if (ImGui.Checkbox("Enable the expanded features for XIVCombo.", ref showExpanded))
            {
                Service.Configuration.EnableExpandedCombos = showExpanded;
                if (!showExpanded)
                {
                    Service.Configuration.EnableAccessibilityCombos = false;
                    Service.Configuration.EnableSecretCombos = false;
                }

                Service.Configuration.Save();
            }

            ImGui.EndChild();
            ImGui.PopStyleVar();

            if (Service.Configuration.EnableExpandedCombos)
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 5f);
                ImGui.BeginChild("ChildBL", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 155f), true, window_flags);

                ImGui.PushFont(UiBuilder.MonoFont);
                ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.HealerGreen);
                ImGui.Text($"Accessibility Combos");
                ImGui.PopStyleColor();
                ImGui.PopFont();
                ImGui.Separator();

                ImGui.BulletText("Those combos are non-optimal routes which simplify a rotation overall.");
                ImGui.BulletText("They are intuitive, and aim at considerably reducing button bloating.");
                ImGui.BulletText("They are meant to be used to give accessibility options to everyone.");
                ImGui.BulletText("They will often lower your ability to perform well in high-end content.");

                ImGui.Separator();

                var showAccessibility = Service.Configuration.EnableAccessibilityCombos;
                if (ImGui.Checkbox("Enable accessibility combos.", ref showAccessibility))
                {
                    Service.Configuration.EnableAccessibilityCombos = showAccessibility;
                    if (!showAccessibility) Service.Configuration.EnableSecretCombos = false;
                    Service.Configuration.Save();
                }

                ImGui.EndChild();
                ImGui.PopStyleVar();
            }

            if (Service.Configuration.EnableAccessibilityCombos)
            {
                ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 5f);
                ImGui.BeginChild("ChildBR", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 155f), true, window_flags);

                ImGui.PushFont(UiBuilder.MonoFont);
                ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DPSRed);
                ImGui.Text($"Secret Combos");
                ImGui.PopStyleColor();
                ImGui.PopFont();
                ImGui.Separator();

                ImGui.BulletText("Those combos are optimization routes which give little benefits.");
                ImGui.BulletText("They often lead to an unintuitive behavior or specific rotation routes.");
                ImGui.BulletText("They generally require a heavy knowledge of your job.");
                ImGui.BulletText("They are niche options, and probably pointless for most players.");
                ImGui.Separator();
                var showSecrets = Service.Configuration.EnableSecretCombos;
                if (ImGui.Checkbox("Enable secret forbidden knowledge.", ref showSecrets))
                {
                    Service.Configuration.EnableSecretCombos = showSecrets;
                    Service.Configuration.Save();
                }

                ImGui.EndChild();
                ImGui.PopStyleVar();
            }

            ImGui.Text("One last thing. If you used to use XIVCombo Expanded before,\nyou should check whether your previous settings correctly imported or not.");
            ImGui.Text("Better be safe than sorry!");
            ImGui.Spacing();
            ImGui.Spacing();

            if (ImGui.Button("Save and Close"))
            {
                Service.Configuration.OneTimePopUp = false;
                Service.Configuration.Save();
            }

            ImGui.Spacing();
            ImGui.Spacing();
        }
    }
}
