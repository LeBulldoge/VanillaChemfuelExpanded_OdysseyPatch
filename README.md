A quick and dirty patch to integrate the gravship engine and vanilla chemfuel tanks into the Vanilla Chemfuel Expanded
pipe network.

This patch turns the vanilla chemfuel tanks into VCE pipe network storage. It also enables the gravengine to consume
chemfuel from the pipe network directly. This means you now have to pipe chemfuel into the engine to be able to take
off.

As a side effect of this, the starting gravship will have empty chemfuel tanks, but I have modified the scenario to
provide the player with the same amount of chemfuel in item form, as well as a VCE chemfuel drain to fill the tanks
with. Just be aware that you need to fill the tanks to take off initially.

Thankfully I was able to make sure that this is safe to add to an existing save, your chemfuel tanks should have the
same amount of fuel they had before this mod was added. I tested this on a few saves of mine and it seemed to work well,
but your mileage may wary. If you encounter issues, you can unload the chemfuel tanks manually, save, and only then add
the mod.