using GTA;
using System;

public class Stolen : Script
{
    public Stolen()
    {
        Tick += OnTick;

        Interval = 300;
    }

    void OnTick(object sender, EventArgs e)
    {
        Player player = Game.Player;

        // Mark jacking vehicle as stolen
        if (player.Character.IsJacking)
        {
            Vehicle vehicle = player.Character.GetVehicleIsTryingToEnter();
            vehicle.IsStolen = true;
        }

        // Mark broken into OR hotwired vehicle as stolen
        if (player.Character.IsGettingIntoAVehicle)
        {
            Vehicle vehicle = player.Character.GetVehicleIsTryingToEnter();

            if (vehicle.LockStatus == VehicleLockStatus.CanBeBrokenInto || vehicle.NeedsToBeHotwired)
            {
                vehicle.IsStolen = true;
            }
        }
    }
}