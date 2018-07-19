using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Leaf.Forms
{
    public static class Prompts
    {
        /// <summary>
        /// Запрашивает подтвержение от пользователя на принудительный выход из программы, с возможной потерей результатов.
        /// Сообщение предлагает изначально нажать "Нет", а после нажать кнопку "Остановить", чтобы результаты работы были сохранены.
        /// </summary>
        /// <returns>
        /// Вернет истину если пользователь согласился на принудительный выход из программы и резкую остановку работы, без сохранения результатов.
        /// </returns>
        public static bool ExitWorkCancel()
        {
            var result = MessageBox.Show(
                "ВНИМАНИЕ: Возможна потеря результатов работы!" + Environment.NewLine +
                "Задачи еще выполняются, прервать их принудительно?" + Environment.NewLine + Environment.NewLine +
                "Рекомендуется ответить \"Нет\", затем нажать красную кнопку \"Стоп\" для плавного завершения и сохранения результатов работ.",
                "Принудительная остановка работы", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Запрос на удаление директории через MessageBox.
        /// </summary>
        /// <param name="name">Имя ресурса который будет очищен, писать с большой буквы</param>
        /// <param name="directory">Пусть до директории что будет удаляться после подтверждения</param>
        public static void ConfirmDeleteDirectory(string name, string directory)
        {
            string nameLower = name.ToLower();
            string caption = $"Удалить {nameLower}?";

            bool notExistsOrEmpty = !Directory.Exists(directory) || !Directory.EnumerateFiles(directory).Any();
            if (notExistsOrEmpty)
            {
                MessageBox.Show("Нечего очищать. Очистка уже была произведена", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ask
            var result = MessageBox.Show($"{name} будут очищены, продолжить?", caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            // Delete
            try
            {
                Directory.Delete(directory, true);
                MessageBox.Show($"{name} очищены!", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось очистить {nameLower} из-за ошибки:\n{ex.Message}", caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
