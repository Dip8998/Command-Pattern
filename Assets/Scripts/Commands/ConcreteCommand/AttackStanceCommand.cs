using Command.Actions;
using Command.Main;
using Command.Player;

public class AttackStanceCommand : UnitCommand
{
    private bool willHitTarget;

    public AttackStanceCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget() => true;

    public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance).PerformAction(actorUnit, targetUnit, willHitTarget);

    public override void Undo()
    {
        if (willHitTarget)
        {
            if (!targetUnit.IsAlive())
                targetUnit.Revive();

            targetUnit.RestoreHealth(actorUnit.CurrentPower);
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}