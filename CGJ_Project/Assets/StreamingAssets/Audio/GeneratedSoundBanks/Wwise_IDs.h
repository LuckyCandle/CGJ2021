/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID CHARA_INJURED = 1705054052U;
        static const AkUniqueID DERAILMENT = 3083640288U;
        static const AkUniqueID FUEL_ADD = 2493820597U;
        static const AkUniqueID FUEL_PICKUP = 2080029592U;
        static const AkUniqueID GAMEOVER = 4158285989U;
        static const AkUniqueID INITIALIZATION = 1980802545U;
        static const AkUniqueID INITIALIZATION_NO_MUSIC = 1912353221U;
        static const AkUniqueID LIGHT_OFF = 3376415477U;
        static const AkUniqueID LIGHT_ON = 3674512137U;
        static const AkUniqueID OBSTACLE_BREAK = 2851453362U;
        static const AkUniqueID RETURN = 3859834159U;
        static const AkUniqueID WIN = 979765101U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_STATUS
        {
            static const AkUniqueID GROUP = 2453052416U;

            namespace STATE
            {
                static const AkUniqueID LOSE = 221232726U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID WIN = 979765101U;
            } // namespace STATE
        } // namespace GAME_STATUS

        namespace TRAIN_STATUS
        {
            static const AkUniqueID GROUP = 2672297998U;

            namespace STATE
            {
                static const AkUniqueID DERAILMENT = 3083640288U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace TRAIN_STATUS

    } // namespace STATES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID FUEL = 2661514705U;
        static const AkUniqueID SPEED = 640949982U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
